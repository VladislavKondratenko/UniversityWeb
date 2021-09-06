using System.Collections.Generic;
using System.Threading.Tasks;
using University.Services.Dto;

namespace University.Services.Interfaces
{
    public interface IService<TDto> where TDto : BaseModelDto
    {
        Task CreateAsync(TDto modelDto);
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetListAsync();
        Task<IEnumerable<TDto>> GetListAsync(int upperLayerId);
        Task EditAsync(TDto modelDto);
        Task DeleteAsync(TDto modelDto);
        Task<bool> VerifyNameAsync(string name);
        Task<bool> VerifyNameAsync(string name, int id);
    }
}