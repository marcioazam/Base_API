using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ResultInfo
{
    public class ResultError(int errorCode, string? key = null, string? value = null, string? message = null)
    {
        public string? Key { get; set; } = key;

        public string? Value { get; set; } = value;

        public string? Message { get; set; } = message;

        public int ErrorCode { get; set; } = errorCode;
    }
}