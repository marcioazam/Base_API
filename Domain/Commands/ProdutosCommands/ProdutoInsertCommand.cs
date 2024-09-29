﻿using Domain.Abstracts.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.ProdutosCommands
{
    public class ProdutoInsertCommand(string nome, decimal valor) : BaseInsertCommand, IRequest<Result>
    {
        public string Nome { get; set; } = nome;

        public decimal Valor { get; set; } = valor;
    }
}