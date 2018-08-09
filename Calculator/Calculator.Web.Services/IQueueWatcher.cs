namespace Calculator.Web.Services
{
    public interface IQueueWatcher
    {
        void AddWatcherUser(IObserver observer);
        void RemoveWatcherUser(IObserver observer);
        void NotifyObservers();
    }
}