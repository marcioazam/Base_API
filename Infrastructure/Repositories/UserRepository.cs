using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Context.Tables;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository(DefaultContext context, IMapper imapper) : BaseRepository<UserTable, User>(context, imapper), IUserRepository
    {
    }
}
