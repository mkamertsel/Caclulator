using YAXLib;

namespace Calculator.Configurations
{
    public class AppConfiguration
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("calculatorId")]
        [YAXAttributeForClass]
        public int CalculatorId { get; set; }

    }
}
