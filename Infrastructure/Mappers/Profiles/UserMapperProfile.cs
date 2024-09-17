using Application.DTOs.Entities;
using Domain.Commands.UsersCommands;
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
                 .ConstructUsing(src => new UserListDTO(src.Id, src.Username));

            CreateMap<UserInsertCommand, User>()
                .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(x => x.Active, opt => opt.MapFrom(src => src.Active))
                .ForMember(x => x.PasswordNoHash, opt => opt.MapFrom(src => src.PasswordNoHash))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => ""));

            CreateMap<UserUpdateCommand, User>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Active, opt => opt.MapFrom(src => src.Active));
        }
    }
}
