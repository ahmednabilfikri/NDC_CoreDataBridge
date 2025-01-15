using NDC_Core_DataBridge.Models;
using NDC_Core_DataBridge.Models.DTOS;
namespace NDC_Core_DataBridge.Interfaces
{
    public interface IFlightBookingRepository : IRepository<TtTsFbSegmentDetail>
    {
        Task<FlightBookDTO> GetFlightBookDetailsAsync(string PNR);
    }
}