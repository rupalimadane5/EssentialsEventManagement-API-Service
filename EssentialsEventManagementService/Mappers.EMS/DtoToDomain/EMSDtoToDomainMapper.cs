using AutoMapper;
using Models.EMS.Domain;
using Models.EMS.Dto;
using Models.EMS.Dto.Contract;

namespace Mappers.EMS.DtoToDomain
{
    public static class EMSDtoToDomainMapper
    {
        private static IMapper mapper = ConfigMapper();

        public static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<EventDomain, EventDto>().ReverseMap();
                cfg.CreateMap<CreateEventRequest, EventDomain>().ReverseMap();

            });

            return mapper = config.CreateMapper();
        }

        public static EventDto ToDto(this EventDomain domain)
        {
            return mapper.Map<EventDto>(domain);
        }

        public static EventDomain ToDomain(this EventDto dto)
        {
            return mapper.Map<EventDomain>(dto);
        }
        public static EventDomain ToDomain(this CreateEventRequest request)
        {
            return mapper.Map<EventDomain>(request);
        }

    }
}
