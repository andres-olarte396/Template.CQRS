using LAOZ.CQRS.Models;
using LAOZ.CQRS.Repositories;
using LAOZ.CQRS.Services;
using Moq;
using NUnit.Framework;

namespace LAOZ.CQRS.Test
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        private Mock<IInvoiceRepository>? _mockRepository;
        private IInvoiceService? _invoiceService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IInvoiceRepository>();
            _invoiceService = new InvoiceService(_mockRepository.Object);
        }

        [Test]
        public void CreateInvoice_ShouldCreateInvoiceAndReturnIt()
        {
            // Arrange
            var customerName = "Test Customer";
            var totalAmount = 50.00m;

            var createdInvoiceId = Guid.NewGuid();
            _mockRepository
                .Setup(repo => 
                    repo.GetById(createdInvoiceId))
                .Returns(
                    new Invoice { 
                        Id = createdInvoiceId, 
                        CustomerName = customerName, 
                        TotalAmount = totalAmount });

            // Act
            var createdInvoice = _invoiceService.CreateInvoice(customerName, totalAmount);

            // Assert
            Assert.That(createdInvoice == null);
            Assert.That(customerName == createdInvoice.CustomerName);
            Assert.That(totalAmount == createdInvoice.TotalAmount);
        }

        [Test]
        public void GetInvoice_ShouldRetrieveInvoiceById()
        {
            // Arrange
            var invoiceId = Guid.NewGuid();
            var expectedInvoice = new Invoice { Id = invoiceId, CustomerName = "Test Customer", TotalAmount = 75.50m };

            _mockRepository.Setup(repo => repo.GetById(invoiceId)).Returns(expectedInvoice);

            // Act
            var retrievedInvoice = _invoiceService.GetInvoice(invoiceId);

            // Assert
            Assert.That(retrievedInvoice == null);
            Assert.That(expectedInvoice.Id == retrievedInvoice.Id);
            Assert.That(expectedInvoice.CustomerName == retrievedInvoice.CustomerName);
            Assert.That(expectedInvoice.TotalAmount == retrievedInvoice.TotalAmount);
        }
    }

}
