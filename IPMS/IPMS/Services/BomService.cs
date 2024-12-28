using IPMS.Interfaces;
using IPMS.Models.DTOs;

namespace IPMS.Services
{
    public class BomService
    {
        private readonly IBillOfMatrialsManagementRepository _bomRepo;

        public BomService(IBillOfMatrialsManagementRepository bomRepository)
        {
      
            _bomRepo = bomRepository;
        }

        public async Task<bool> UpdateListOfMatrials(List<BomDto> listOfMatrials)
        {
            try
            {
                foreach (var bom in listOfMatrials)
                {
                    await _bomRepo.UpdateBom(bom);
                }
                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
       
        }
    }
}
