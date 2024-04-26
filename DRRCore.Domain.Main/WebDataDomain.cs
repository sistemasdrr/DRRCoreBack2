using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main
{
    public class WebDataDomain : IWebDataDomain
    {
        private readonly IMySqlWebRepository _mySqlWebRepository;
        private readonly IWebQueryRepository _webQueryRepository;
        public WebDataDomain(IMySqlWebRepository mySqlWebRepository, IWebQueryRepository webQueryRepository)
        {
            _mySqlWebRepository = mySqlWebRepository;
            _webQueryRepository = webQueryRepository;
        }
        public async Task<bool> AddOrUpdateWebDataAsync()
        {
                var listadoGeneral = await _mySqlWebRepository.Get();
                if (listadoGeneral.Count > 0)
                {
                    await _webQueryRepository.UpdateData(listadoGeneral);
                }
            return true;
        }

        public async Task<WebQuery> GetByCodeAsync(string code)
        {
            return await _webQueryRepository.GetByCodeAsync(code);
        }

        public async Task<List<WebQuery>> GetByCountryAndBranchAsync(int country, string branch, int page)
        {
            return await _webQueryRepository.GetByCountryAndBranchAsync(country,branch, page);
        }

        public async Task<List<WebQuery>> GetByParamAndCountryAsync(string param, string country)
        {
            return await _webQueryRepository.GetByParamAndCountryAsync(param,country);
        }

        public async Task<List<WebQuery>> GetByParamAsync(string param, int page)
        {
            return await _webQueryRepository.GetByParamAsync(param,page);           
        }

        public async Task<string> GetOldCodeAsync(string code)
        {
            return await _webQueryRepository.GetOldCodeAsync(code);
        }

        public async Task<List<WebQuery>> GetSimilarBrunchAsync(string code)
        {
            return await _webQueryRepository.GetSimilarBrunchAsync(code);
        }
    }
}
