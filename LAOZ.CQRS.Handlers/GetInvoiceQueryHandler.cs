using LAOZ.CQRS.Models;
using LAOZ.CQRS.Queries;
using LAOZ.CQRS.Repositories;

namespace LAOZ.CQRS.Handlers
{
    public class GetInvoiceQueryHandler
    {
        private readonly IInvoiceRepository _repository;

        public GetInvoiceQueryHandler(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public Invoice Handle(GetInvoiceQuery query)
        {
            return _repository.GetById(query.InvoiceId);
        }
    }
}
