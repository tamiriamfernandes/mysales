namespace MySales.Model.Entities
{
    public class AccountReceive
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public long CustomerId { get; set; }
        public int NumberParcel { get; set; }
        public DateTime DatePay { get; set; }
        public decimal Total { get; set; }
        public DateTime DatePaid { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
