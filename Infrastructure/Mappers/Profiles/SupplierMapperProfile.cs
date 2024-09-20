using Application.DTOs.Entities;
using Application.DTOs.Filters;
using Domain.Commands.SuppliersCommands;
using Domain.Entities;
using Infrastructure.Context.Tables;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers.Profiles
{
    internal class SupplierMapperProfile : ProfileBase
    {
        public SupplierMapperProfile()
        {
            CreateMap<SupplierTable, Supplier>().ReverseMap();

            CreateMap<SupplierTable, SupplierListDTO>();

            CreateMap<SupplierInsertCommand, Supplier>();

            CreateMap<SupplierUpdateCommand, Supplier>();
        }
    }
}
