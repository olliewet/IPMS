using IPMS.Models.DTOs;

namespace IPMS.Interfaces
{
    public interface IBillOfMatrialsManagementRepository
    {
        Task<bool> AddBom(BomDto bom);
        Task<bool> RemoveBom(BomDto bom);
        Task<bool> UpdateBom(BomDto bom);
        Task<List<BomDto>> GetAllBomsFromId(string id);
    }
}
