using Dapper;
using LAOZ.CQRS.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace LAOZ.CQRS.Repositories
{
    public class DapperInvoiceRepository(IConfiguration configuration) : IInvoiceRepository
    {
        private string _connectionString = configuration.GetConnectionString("DefaultConnection");

        public string ConnectionString => _connectionString;

        public Invoice GetById(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Invoices WHERE Id = @Id";
            return connection.QueryFirstOrDefault<Invoice>(query, new { Id = id });
        }

        public bool Save(Invoice invoice)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "INSERT INTO Invoices (Id, CustomerName, TotalAmount) VALUES (@Id, @CustomerName, @TotalAmount)";
            return connection.Execute(query, invoice) > 0;
        }
    }
}
