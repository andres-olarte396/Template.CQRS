namespace LAOZ.CQRS.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        // Otros campos relevantes
    }

}
