using AutoMapper;
using Models.EMS.Domain;
using Models.EMS.Entity;

namespace Mappers.EMS.EntityToDomain
{
    public static class EMSEntityToDomainMapper
    {
        private static IMapper mapper = ConfigMapper();

        public static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<EventEntity, EventDomain>()
                    .ForMember(dest => dest.Event, m => m.MapFrom(src => src.pkEvent))
                    .ForMember(dest => dest.EventName, m => m.MapFrom(src => src.sEventName))
                    .ForMember(dest => dest.EventDate, m => m.MapFrom(src => src.sEventDate))
                    .ForMember(dest => dest.EventTime, m => m.MapFrom(src => src.sEventTime))
                    .ForMember(dest => dest.EventColor, m => m.MapFrom(src => src.sEventColor))
                    .ReverseMap();

            });

            return mapper = config.CreateMapper();
        }

        public static EventDomain ToDomain(this EventEntity entity)
        {
            return mapper.Map<EventDomain>(entity);
        }

        public static EventEntity ToEntity(this EventDomain domain)
        {
            return mapper.Map<EventEntity>(domain);
        }
    }
}
