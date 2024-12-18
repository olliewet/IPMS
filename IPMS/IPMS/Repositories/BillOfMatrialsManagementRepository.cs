using IPMS.Data;
using IPMS.Helpers;
using IPMS.Interfaces;
using IPMS.Models.DTOs;
using IPMS.Models.EF;

namespace IPMS.Repositories
{
    public class BillOfMatrialsManagementRepository : IBillOfMatrialsManagementRepository
    {
        ApplicationDBContext _context;

        public BillOfMatrialsManagementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBom(BomDto bom)
        {
            try
            {
                _context.BomManagement.Add(BomMapper.GetEfromDto(bom));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }

        public async Task<List<BomDto>> GetAllBomsFromId(string id)
        {
            List<BomDto> result = new();
            try
            {
                var list = _context.BomManagement;
                foreach (var item in list)
                {
                    if(item.ProductId == id)
                    {
                        result.Add(BomMapper.GetDtoFromEFModel(item));
                    }            
                }
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex) { }
            {
                return result;
            }
        }

        public async Task<bool> UpdateBom(BomDto bom)
        {
            try
            {
                _context.BomManagement.Update(BomMapper.GetEfromDto(bom));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }
    }
}
