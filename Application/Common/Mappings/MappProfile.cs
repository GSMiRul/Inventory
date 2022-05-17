using AutoMapper;
using System;

namespace Application.Common.Mappings
{
    public class MappProfile<TSource, TDestination> : Profile
    {
        public TDestination MapResponse { get; init; }
        public MappProfile(IMapper mapper, TSource request)
        {
            CreateMap<TSource, TDestination>();

            MapResponse = mapper.Map<TDestination>(request);
        }
    }
}
