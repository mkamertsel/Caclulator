using YAXLib;

namespace Calculator.Configurations
{
    public class SqlConfiguration
    {
        [YAXErrorIfMissed(YAXExceptionTypes.Error)]
        [YAXSerializeAs("connectionString")]
        [YAXAttributeForClass]
        public string ConnectionString { get; set; }

    }
}
