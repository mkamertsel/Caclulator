using Calculator.Common.Enums;
using Calculator.Dal.Mappers.DbToDto;
using Calculator.Db.Models;
using NUnit.Framework;

namespace Dal.Tests.MappersTests.DbToDto
{
    [TestFixture]
    public class OperationMapperTest
    {
        [Test]
        public void MapOperationTest()
        {
            var dbOperation = new Operation
            {
                CalculatorId = 123,
                FirstNumber = 77,
                SecondNumber = 11,
                OperationType = 0,
                OperationId = 423
            };
            var mapper = new OperationMapper();
            var result = mapper.Map(dbOperation);

            Assert.AreEqual(result.CalculatorId, 123);
            Assert.AreEqual(result.FirstNumber, 77);
            Assert.AreEqual(result.SecondNumber, 11);
            Assert.AreEqual(result.OperationType, OperationType.Addition);
            Assert.AreEqual(result.OperationId, 423);
        }
    }
}
