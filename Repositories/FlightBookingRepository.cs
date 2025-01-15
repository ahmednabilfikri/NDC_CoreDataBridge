using Microsoft.EntityFrameworkCore;
using NDC_Core_DataBridge.Interfaces;
using NDC_Core_DataBridge.Models;
using NDC_Core_DataBridge.Models.Context;
using NDC_Core_DataBridge.Models.DTOS;

namespace NDC_Core_DataBridge.Repositories
{
    internal class FlightBookingRepository : Repository<TtTsFbSegmentDetail>, IFlightBookingRepository
    {
        private readonly NdcCoreDbContext _context;
        internal FlightBookingRepository(NdcCoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FlightBookDTO> GetFlightBookDetailsAsync(string PNR)
        {
            return await _context.TtTsFbSegmentDetails
                 .Where(a => a.SpPnr == PNR)
                 .Select(a => new FlightBookDTO
                 {
                     BookingReference = a.FbBookingRefNo
                 })
                 .FirstOrDefaultAsync();
        }
    }
}
