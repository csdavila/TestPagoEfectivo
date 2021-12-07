using AutoMapper;
using PagoEfectivo.PromoCode.Model.Dtos;
using PagoEfectivo.PromoCode.Model.Models;

namespace PagoEfectivo.PromoCode.CrossCuting.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<PromoCodeDto, PromoCodeEntity>().ReverseMap();
        }
    }
}
