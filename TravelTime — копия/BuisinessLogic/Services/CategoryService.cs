using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }

        public async Task<Category> GetById(int id)
        {
            var user = await _repositoryWrapper.Category.FindByCondition(x => x.Idcategory == id);
            return user.First();
        }

        public async Task Create(Category model)
        {
            await _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Category model)
        {
            _repositoryWrapper.Category.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Category.FindByCondition(x => x.Idcategory == id);

            _repositoryWrapper.Category.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}