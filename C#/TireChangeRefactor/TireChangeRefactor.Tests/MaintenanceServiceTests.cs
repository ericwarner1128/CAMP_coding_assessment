using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TireChangeRefactor.Tests
{
    [TestClass]
    public class MaintenanceServiceTests
    {
        [TestMethod]
        public void MaintenanceService_GetAllAircraftDueForTireChange()
        {
            // Arrange
            var mtxSvc = new MaintenanceService();
            var expected = new[] {1, 3, 5};

            // Act
            var actual = mtxSvc.GetAllAircraftDueForTireChange().Select(x => x.Id).ToArray();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
