using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Base
{
    public class CommandResult
    {
        public CommandResult(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public CommandResult(bool sucesso, long id)
        {
            Sucesso = sucesso;
            Id = id;
        }

        public CommandResult(bool sucesso, string? erro = null)
        {
            Sucesso = sucesso;

            Erros =
            [
                new CommandResultErro("Geral", erro)
            ];
        }

        public CommandResult(bool sucesso, IList<CommandResultErro>? erros = null)
        {
            Sucesso = sucesso;
            Erros = erros;
        }

        public bool Sucesso { get; set; }

        public long Id { get; set; }

        public IList<CommandResultErro>? Erros { get; private set; }
    }

    public class CommandResultErro(string propriedade, string? mensagem)
    {
        public string Propriedade { get; set; } = propriedade;

        public string? Mensagem { get; set; } = mensagem;
    }
}
