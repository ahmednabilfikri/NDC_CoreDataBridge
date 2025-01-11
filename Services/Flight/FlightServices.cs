using Microsoft.EntityFrameworkCore;
using NDC_Core_DataBridge.Helpers;
using NDC_Core_DataBridge.Models;
using NDC_Core_DataBridge.Models.Context;
using NDC_Core_DataBridge.Models.DTOS;

namespace NDC_Core_DataBridge.Services.Flight
{
    internal sealed class FlightServices : IFlightServices
    {
        private readonly NdcCoreDbContext _ndcCoreDbContext;
        internal FlightServices(CredentialsDto credentialsDto)
        {
            if (credentialsDto == null)
                throw new ArgumentNullException(nameof(credentialsDto));

            // Build the connection string and initialize the DbContext.
            var connectionString = ConnectionStringBuilder.BuildConnectionString(credentialsDto);
            _ndcCoreDbContext = new NdcCoreDbContext(connectionString);
        }

        public async Task<FlightBookDTO> GetFlightBookDetails(string PNR)
        {
            return await _ndcCoreDbContext.TtTsFbSegmentDetails.Where(a => a.SpPnr == PNR)
                .Select(a => new FlightBookDTO
                {
                    BookingReference = a.FbBookingRefNo
                }).FirstOrDefaultAsync();
        }
    }
}
