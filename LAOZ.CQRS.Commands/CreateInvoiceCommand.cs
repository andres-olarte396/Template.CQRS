
namespace LAOZ.CQRS.Commands
{
    public class CreateInvoiceCommand(Guid id, int version) : Command(id, version)
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        // Otros campos relevantes
    }
}
