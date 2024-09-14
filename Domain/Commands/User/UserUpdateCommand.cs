using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User
{
    public class UserUpdateCommand(long id, string nome, string apiUrl, string apiKey) : IRequest<Result>, IBaseUpdateCommand
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string ApiUrl { get; set; } = apiUrl;

        public string ApiKey { get; set; } = apiKey;
    }
}
