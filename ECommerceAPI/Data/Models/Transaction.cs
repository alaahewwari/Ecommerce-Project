using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ECommerceAPI.Data.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public TransactionStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public long PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
