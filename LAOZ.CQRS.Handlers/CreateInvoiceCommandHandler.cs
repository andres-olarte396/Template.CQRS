using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Models;
using LAOZ.CQRS.Repositories;

namespace LAOZ.CQRS.Handlers
{
    public class CreateInvoiceCommandHandler(IInvoiceRepository repository) : ICommandHandler<CreateInvoiceCommand> 
    {
        private readonly IInvoiceRepository _repository = repository;

        public void Handle(CreateInvoiceCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerName = command.CustomerName,
                TotalAmount = command.TotalAmount
            };

            _repository.Save(invoice);
        }
    }
}
