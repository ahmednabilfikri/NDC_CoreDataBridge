namespace NDC_Core_DataBridge.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        IFlightBookingRepository FlightBookingRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
