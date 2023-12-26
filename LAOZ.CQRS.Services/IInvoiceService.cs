using LAOZ.CQRS.Models;

namespace LAOZ.CQRS.Services
{
    public interface IInvoiceService
    {
        Invoice CreateInvoice(string customerName, decimal totalAmount);
        Invoice GetInvoice(Guid invoiceId);
    }
}
