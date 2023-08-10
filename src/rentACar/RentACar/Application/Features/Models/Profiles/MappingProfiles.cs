using Application.Features.Models.Queries.GetList;
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
        CreateMap<Paginate<Model>,GetListResponse<GetListModelListItemDto> >().ReverseMap();

        // Eğer Models içerisindeki bir property ile başka bir entity'nin property'sini eşleştirmek istiyorsak
        // örneğin Model içerisindeki BrandId property'sini BrandName property'si ile eşleştirmek istiyorsak
        // aşağıdaki gibi bir kod yazabiliriz.
        // CreateMap<Model, GetListModelListItemDto>()
        //     .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
        //     .ReverseMap();

    }
}
