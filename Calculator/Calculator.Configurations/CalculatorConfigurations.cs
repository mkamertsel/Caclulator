using YAXLib;

namespace Calculator.Configurations
{
    [YAXSerializeAs("calc")]
    public class CalculatorConfigurations
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("db")]
        public DbConfiguration Db { get; set; }

        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("app")]
        public AppConfiguration App { get; set; }

        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("watcher")]
        public WatcherConfiguration Watcher { get; set; }

    }
}
