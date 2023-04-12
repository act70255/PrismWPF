using AutoMapper;
using Checo.Models;
using Checo.Repository.Entity;

namespace Checo.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, Item>();
            CreateMap<Trade, TradeModel>();
            CreateMap<TradeModel, Trade>();
            CreateMap<TradeDetail, TradeDetailModel>();
            CreateMap<TradeDetailModel, TradeDetail>();
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
