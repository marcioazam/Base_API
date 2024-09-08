using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.ResultInfo
{
    public class Result(object? data, List<ResultError> errors)
    {
        public object? Data { get; set; } = data;

        public List<ResultError> Errors { get; set; } = errors;

        public bool Failed()
        {
            if (Errors.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
