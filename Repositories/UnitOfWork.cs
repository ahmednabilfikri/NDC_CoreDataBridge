using NDC_Core_DataBridge.Interfaces;
using NDC_Core_DataBridge.Models.Context;

namespace NDC_Core_DataBridge.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly NdcCoreDbContext _context;
        private IFlightBookingRepository _flightBookingRepository;
        public UnitOfWork(NdcCoreDbContext context)
        {
            _context = context;
        }

        public IFlightBookingRepository FlightBookingRepository
        {
            get
            {
                if (_flightBookingRepository == null)
                {
                    _flightBookingRepository = new FlightBookingRepository(_context);
                }
                return _flightBookingRepository;
            }
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_context); 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
