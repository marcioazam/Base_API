using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ResultInfo
{
    public class ResultError(string? key = null, string? value = null, string? message = null)
    {
        public string? Key { get; set; } = key;

        public string? Value { get; set; } = value;

        public string? Message { get; set; } = message;

        public bool Failed()
        {
            // Se a propriedade e a mensagem estiverem vazias, não há erro
            if (string.IsNullOrEmpty(Key) && string.IsNullOrEmpty(Value) && string.IsNullOrEmpty(Message))
            {
                return false;
            }

            return true;
        }
    }
}