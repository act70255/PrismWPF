using Checo.Models;
using System;
using System.Collections.Generic;

namespace Checo.Service.Interface
{
    public interface ITradeService
    {
        IEnumerable<TradeModel> Get();
        public void Insert(TradeModel model);
        void Delete(int id);
    }
}
