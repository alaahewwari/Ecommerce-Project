namespace ECommerceAPI.Data.Enums
{
    /// <summary>
    /// this enum represents the status of a transaction in the system (Pending, Approved, Rejected)
    /// </summary>
    public enum TransactionStatus
    {
        None = 0,
        Pending=1,
        Approved=2,
        Rejected=3
    }
}
