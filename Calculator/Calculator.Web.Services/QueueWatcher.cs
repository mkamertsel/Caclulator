using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Calculator.Common.Entities;
using Calculator.Configurations;
using Calculator.Dal.Repository;

namespace Calculator.Web.Services
{
    public class QueueWatcher : IQueueWatcher
    {
        private readonly IQueueRepository repository;
        private readonly IConfiguration configuration;

        private List<IObserver> observers;
        private IEnumerable<Operation> operations;
        private Timer watchTimer;

        public QueueWatcher(IQueueRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
            observers = new List<IObserver>();
        }

        public void AddWatcherUser(IObserver observer)
        {
            if (!observers.Any())
            {
                InitQueueWatcher();
            }
            observers.Add(observer);
        }

        public void RemoveWatcherUser(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers)
            {
                o.Update(operations);
            }
        }

        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            var queue = repository.GetQueue();
            if (!queue.Any())
            {
                return;
            }
            operations = queue;
            NotifyObservers();

            watchTimer.Start();
        }

        private void InitQueueWatcher()
        {
            var period = configuration.CheckingPeriod;
            watchTimer = new Timer();
            watchTimer.Elapsed += TimerElapsed;
            watchTimer.Interval = period;
            watchTimer.AutoReset = false;
            watchTimer.Enabled = true;
        }
    }
}