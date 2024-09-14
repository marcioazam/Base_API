using Domain.EnumTypes;
using Domain.Helpers;
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

        public void AddError(GlobalError error, object? keyAndValue)
        {
            string? value = null;

            if(keyAndValue != null)
            {
                value = keyAndValue.ToString();
            }

            this.Errors.Add(new ResultError((int)error, nameof(keyAndValue), value, EnumHelper.GetDesc(error)));
        }

        public void AddError(GlobalError error, string key, string value, string? customMessage = null)
        {
            string? message;

            if (!string.IsNullOrEmpty(customMessage))
            {
                message = customMessage;
            }
            else
            {
                message = EnumHelper.GetDesc(error);
            }

            this.Errors.Add(new ResultError((int)error, key, value, message));
        }
    }
}
