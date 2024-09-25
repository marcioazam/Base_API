using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EnumTypes
{
    public enum GlobalError
    {
        [Description("O campo [PROPERTY_NAME] é obrigatório.")]
        RequiredProperty = 0,
        [Description("O campo [PROPERTY_NAME] precisa ter no mínimo [LENGTH] caracteres.")]
        MinLenProperty = 1,
        [Description("O campo [PROPERTY_NAME] suporta até [LENGTH] caracteres.")]
        MaxnLenProperty = 2,
        [Description("Dados não encontrados, verifique o índice de sua busca.")]
        NotFound = 3,
        [Description("Acesso negado.")]
        Unauthorized = 4,
        [Description("O nome de usuário é obrigatório.")]
        RequiredUsername = 5,
        [Description("A senha é obrigatória.")]
        RequiredPassword = 6,
        [Description("Usuário não encontrado, verifique seu login e senha.")]
        UserNotFound = 7,
        [Description("Senha inválida.")]
        InvalidPassword = 8,
        [Description("Erro interno.")]
        InternalError = 9,
        [Description("Propriedade inválida.")]
        InvalidProperty = 10,
        [Description("O request foi identificado como uma operação maliciosa.")]
        RequestMalicious = 11,
        [Description("Refresh Token expirado.")]
        RefreshTokenExpired = 12,
    }
}
