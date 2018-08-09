using System;
using System.Collections.Generic;
using System.Windows;
using Calculator.Loggers;
using Calculator.Ui.Wpf.Presentation.ViewModels;
using Calculator.Web.Services;
using Caliburn.Micro;

namespace Calculator.Ui.Wpf
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Instance(container);
            container.Singleton<IWindowManager, WindowManager>().Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<ShellViewModel>();
            container.Singleton<IActivityLogger, ActivityLogger>();
            container.Singleton<IResultSenderService, ResultSenderService>();

            container.Singleton<ICalculationAgregator, CalculationAgregator>();
        }
        protected override void OnStartup(object sender, StartupEventArgs args)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
