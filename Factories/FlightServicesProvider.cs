using NDC_Core_DataBridge.Models;
using NDC_Core_DataBridge.Services.Flight;

namespace NDC_Core_DataBridge.Factories
{
    public static class FlightServicesProvider
    {
        public static IFlightServices GetFlightServices(CredentialsDto credentialsDto)
        {
            return new FlightServices(credentialsDto);
        }
    }
}
