using NDC_Core_DataBridge.Interfaces;
using NDC_Core_DataBridge.Models.DTOS;

namespace NDC_Core_DataBridge.Services.Flight
{
    public class FlightServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<FlightBookDTO> GetFlightBookDetails(string PNR)
        {
            return await _unitOfWork.FlightBookingRepository.GetFlightBookDetailsAsync(PNR);
        }
        public async Task<IEnumerable<T>> GetAllEntities<T>() where T : class
        {
            return await _unitOfWork.Repository<T>().GetAllAsync();
        }
    }
}
