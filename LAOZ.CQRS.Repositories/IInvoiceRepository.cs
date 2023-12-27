using LAOZ.CQRS.Models;

namespace LAOZ.CQRS.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetById(Guid id);
        bool Save(Invoice invoice);
    }
}
