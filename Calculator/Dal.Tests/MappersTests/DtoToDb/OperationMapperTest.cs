using Calculator.Common.Enums;
using NUnit.Framework;

namespace Dal.Tests.MappersTests.DtoToDb
{
    [TestFixture]
    public class OperationMapperTest
    {
        [Test]
        public void MapOperationTest()
        {
            var dtoOperation = new Calculator.Common.Entities.Operation
            {
                CalculatorId = 123,
                FirstNumber = 77,
                SecondNumber = 11,
                OperationType = OperationType.Addition,
                OperationId = 423
            };
            var mapper = new Calculator.Dal.Mappers.DtoToDb.OperationMapper();
            var result = mapper.Map(dtoOperation);

            Assert.AreEqual(result.CalculatorId, 123);
            Assert.AreEqual(result.FirstNumber, 77);
            Assert.AreEqual(result.SecondNumber, 11);
            Assert.AreEqual(result.OperationType, OperationType.Addition);
            Assert.AreEqual(result.OperationId, 423);
        }
    }
}
