using AutoMapper;
using Checo.Models;
using Checo.Repository.Context;
using Checo.Repository.Entity;
using Checo.Repository.Interface;
using Checo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Service
{
    public class TradeService : BaseService, ITradeService
    {
        #region Property
        IRepository<Trade> _tradeRepository;
        IUtilityService _utilityService;
        #endregion

        #region Constructor
        public TradeService(IRepository<Trade> _repository, IUtilityService utilityService)
        {
            _tradeRepository = _repository;
            _utilityService = utilityService;
        }
        #endregion

        public IEnumerable<TradeModel> Get()
        {
            var entity = _tradeRepository.GetAll();
            return _utilityService.MapList<TradeModel>(entity);
        }

        public void Insert(TradeModel model)
        {
            _tradeRepository.Insert(_mapper.Map<Trade>(model));
        }

        public void Delete(int id)
        {
            Trade Trade = _tradeRepository.GetAll().FirstOrDefault(c => c.ID.Equals(id));
            _tradeRepository.Remove(Trade);
            _tradeRepository.SaveChanges();
        }
    }
}
