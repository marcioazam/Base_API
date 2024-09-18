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

            CreateMap<UserTable, UserListDTO>();

            CreateMap<UserInsertCommand, User>();

            CreateMap<UserUpdateCommand, User>();
        }
    }
}
