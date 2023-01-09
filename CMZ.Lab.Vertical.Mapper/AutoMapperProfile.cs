using AutoMapper;
using CMZ.Lab.Application.DTO;
using CMZ.Lab.Domain.Entity;

namespace CMZ.Lab.Vertical.Mapper
{
    /// <summary>
    /// Profile for automapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<Subscription, SubscriptionDTO>()
                .ForMember(dto => dto.NameFrecuency, ent => ent.MapFrom(prop => prop.NotificationFrecuencie.Name))
                .ForMember(dto => dto.NameActivityType, ent => ent.MapFrom(prop => prop.EntityActivityType.Name));

            CreateMap<CreateSubscriptionDTO,Subscription>();
        }
    }
}
