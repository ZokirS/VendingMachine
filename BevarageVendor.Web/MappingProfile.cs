using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace VendingMachine.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coin, CoinDto>().ReverseMap();
            CreateMap<Beverage, BeverageDto>().ReverseMap();
        }
    }
}
