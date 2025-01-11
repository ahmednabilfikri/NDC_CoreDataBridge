using NDC_Core_DataBridge.Models.DTOS;

namespace NDC_Core_DataBridge.Services.Flight
{
    public interface IFlightServices
    {
        public Task<FlightBookDTO> GetFlightBookDetails(string PNR);
    }
}
