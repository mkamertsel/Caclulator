using Calculator.Configurations;
using Calculator.Dal.Mappers;
using Calculator.Dal.Repository;
using Calculator.Loggers;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Lifestyles;
using Operation = Calculator.Common.Entities.Operation;
using OperationMapper = Calculator.Dal.Mappers.DtoToDb.OperationMapper;

namespace Calculator.Web.Services
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterSingleton<Configuration>();
            container.RegisterSingleton<IConfiguration>(container.GetInstance<Configuration>);
            container.RegisterSingleton<IUpdateConfiguration>(container.GetInstance<Configuration>);

            container.RegisterSingleton<IConfigurationReader, ConfigurationReader>();
            container.RegisterSingleton<IActivityLogger, ActivityLogger>();

            container.Register<IMapper<Operation, Db.Models.Operation>, OperationMapper>();
            container.Register<IMapper<Db.Models.Operation, Operation>, Dal.Mappers.DbToDto.OperationMapper>();

            container.Register<IResultSenderService, ResultSenderService>();
            container.Register<IQueueWatcher, QueueWatcher>();

            container.Register<ICalculationAgregator, CalculationAgregator>();
            container.Register<ICalculationEngine, CalculationEngine>();
            container.Register<ICalculationHelper, CalculationHelper>();

            container.Register<IQueueRepository, QueueRepository>();

            //container.RegisterWcfServices(Assembly.GetExecutingAssembly());
            container.Verify();

            SimpleInjectorServiceHostFactory.SetContainer(container);

            var reader = container.GetInstance<IConfigurationReader>();
            reader.ReadConfiguration();
        }
    }
}