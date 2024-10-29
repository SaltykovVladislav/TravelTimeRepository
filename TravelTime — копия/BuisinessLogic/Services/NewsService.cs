using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;


namespace BusinessLogic.Services
{
    public class NewsService : INewsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NewsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<News>> GetAll()
        {
            return await _repositoryWrapper.News.FindAll();
        }

        public async Task<News> GetById(int id)
        {
            var News = await _repositoryWrapper.News.FindByCondition(x => x.Idnews == id);
            return News.First();
        }

        public async Task Create(News model)
        {
            await _repositoryWrapper.News.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(News model)
        {
            _repositoryWrapper.News.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var News = await _repositoryWrapper.News.FindByCondition(x => x.Idnews == id);

            _repositoryWrapper.News.Delete(News.First());
            _repositoryWrapper.Save();
        }
    }
}

