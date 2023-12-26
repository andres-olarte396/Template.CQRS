using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Handlers;
using LAOZ.CQRS.Models;
using LAOZ.CQRS.Queries;
using LAOZ.CQRS.Repositories;

namespace LAOZ.CQRS.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public Invoice CreateInvoice(string customerName, decimal totalAmount)
        {
            var createInvoiceCommand = new CreateInvoiceCommand(Guid.NewGuid(), 0)
            {
                CustomerName = customerName,
                TotalAmount = totalAmount
            };

            var createInvoiceHandler = new CreateInvoiceCommandHandler(_repository);
            createInvoiceHandler.Handle(createInvoiceCommand);

            return _repository.GetById(createInvoiceCommand.Id);
        }

        public Invoice GetInvoice(Guid invoiceId)
        {
            var getInvoiceQuery = new GetInvoiceQuery
            {
                InvoiceId = invoiceId
            };

            var getInvoiceHandler = new GetInvoiceQueryHandler(_repository);
            return getInvoiceHandler.Handle(getInvoiceQuery);
        }
    }

}
