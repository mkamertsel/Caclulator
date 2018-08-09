using YAXLib;

namespace Calculator.Configurations
{
    public class DbConfiguration
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("sql")]
        public SqlConfiguration Sql { get; set; }
    }
}
