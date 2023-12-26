using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Repositories;
using LAOZ.CQRS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LAOZ.CQRS.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configuración de servicios
            var serviceProvider = new ServiceCollection()
                .AddScoped<IConfiguration, Configuration>()
                .AddScoped<IInvoiceRepository, DapperInvoiceRepository>()
                .AddScoped<IInvoiceService, InvoiceService> ()
                .BuildServiceProvider();

            // Ejemplo de uso
            var invoiceService = serviceProvider.GetRequiredService<IInvoiceService>();

            var createInvoiceCommand = new CreateInvoiceCommand(Guid.NewGuid(), 1)
            {
                CustomerName = "Cliente A",
                TotalAmount = 100.00m
            };

            var createdInvoice = invoiceService.CreateInvoice(createInvoiceCommand.CustomerName, createInvoiceCommand.TotalAmount);
            Console.WriteLine($"Invoice created with ID: {createdInvoice.Id}");

            var invoiceIdToRetrieve = createdInvoice.Id;
            var retrievedInvoice = invoiceService.GetInvoice(invoiceIdToRetrieve);

            // Ahora 'retrievedInvoice' contiene la factura recuperada
            Console.WriteLine($"Retrieved Invoice: ID: {retrievedInvoice.Id}, Customer: {retrievedInvoice.CustomerName}, Amount: {retrievedInvoice.TotalAmount}");
        }
    }
}
