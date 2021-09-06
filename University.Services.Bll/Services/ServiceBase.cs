using System.Collections.Generic;
using System.Threading.Tasks;
using University.Services.Dto;
using University.Services.Interfaces;

namespace University.Services
{
    public abstract class ServiceBase<TDto> : IService<TDto> where TDto : BaseModelDto
    {
        private readonly IAssistant<TDto> _assistant;

        protected ServiceBase(IAssistant<TDto> assistant)
        {
            _assistant = assistant;
        }

        protected IAssistant<TDto> Assistant =>
            _assistant;

        public virtual async Task CreateAsync(TDto modelDto)
        {
            await _assistant.CreateAsync(modelDto);
        }

        public virtual async Task DeleteAsync(TDto modelDto)
        {
            await _assistant.DeleteAsync(modelDto);
        }

        public virtual async Task EditAsync(TDto modelDto)
        {
            await _assistant.EditAsync(modelDto);
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            return await _assistant.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<TDto>> GetListAsync()
        {
            return await _assistant.GetListAsync();
        }

        public virtual async Task<IEnumerable<TDto>> GetListAsync(int upperLayerId)
        {
            return await _assistant.GetListAsync(upperLayerId);
        }

        public abstract Task<bool> VerifyNameAsync(string name);

        public abstract Task<bool> VerifyNameAsync(string name, int id);
    }
}