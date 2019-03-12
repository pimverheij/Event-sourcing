using AutoMapper;
using Eventsourcing.Messages.Commands;
using Eventsourcing.Messages.Events;
using Eventsourcing.Models;
using System;

namespace Eventsourcing.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCustomer, CustomerCreated>()
                .ForMember(x => x.MessageType, opt => opt.Ignore());

            CreateMap<AddProduct, CartCreated>()
                .ForMember(x => x.CartId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(x => x.MessageId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(x => x.MessageType, opt => opt.Ignore())
                .ForMember(x => x.CorrolationId, opt => opt.MapFrom(src => src.CustomerId));

            CreateMap<AddProduct, ProductAdded>()
                .ForMember(x => x.MessageType, opt => opt.Ignore())
                .ForMember(x => x.CorrolationId, opt => opt.MapFrom(src => src.CustomerId));

            CreateMap<Product, ProductAdded>()
                .ForMember(x => x.MessageId, opt => opt.Ignore())
                .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.ProductPrice, opt => opt.MapFrom(src => src.Price));
        }
    }
}
