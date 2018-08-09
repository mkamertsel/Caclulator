using YAXLib;

namespace Calculator.Configurations
{
    public class WatcherConfiguration
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("checkingPeriodInMs")]
        [YAXAttributeForClass]
        public int CheckingPeriodInMs { get; set; }
    }
}
