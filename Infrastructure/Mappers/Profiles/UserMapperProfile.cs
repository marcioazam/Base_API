using Application.DTOs.Entities;
using Domain.Commands.User;
using Domain.Entities;
using Infrastructure.Context.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers.Profiles
{
    internal class UserMapperProfile : ProfileBase
    {
        public UserMapperProfile()
        {
            CreateMap<UserTable, User>().ReverseMap();

            CreateMap<UserTable, UserListDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username)).ReverseMap();

            CreateMap<UserInsertCommand, User>()
                .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(x => x.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<UserUpdateCommand, User>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Active, opt => opt.MapFrom(src => src.Active));
        }
    }
}
