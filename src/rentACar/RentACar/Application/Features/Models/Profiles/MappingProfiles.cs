using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListItemDto>().ReverseMap();
        CreateMap<Model, GetListByDynamicModelListItemDto>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(src => src.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(src => src.Transmission.Name))
            .ReverseMap();

        CreateMap<Paginate<Model>,GetListResponse<GetListModelListItemDto> >().ReverseMap();

        CreateMap<Paginate<Model>,GetListResponse<GetListByDynamicModelListItemDto> >().ReverseMap();

        // Eğer Models içerisindeki bir property ile başka bir entity'nin property'sini eşleştirmek istiyorsak
        // örneğin Model içerisindeki BrandId property'sini BrandName property'si ile eşleştirmek istiyorsak
        // aşağıdaki gibi bir kod yazabiliriz.
        // CreateMap<Model, GetListModelListItemDto>()
        //     .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
        //     .ReverseMap();

    }
}
