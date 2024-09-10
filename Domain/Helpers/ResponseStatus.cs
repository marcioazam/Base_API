using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public enum ResponseStatus
    {
        Unauthorized = 401,
        Forbidden = 403,
        Created = 201,
        NoContent = 204,
        NotFound = 404,
        InternalServerError = 500,
        Ok = 200,
        BadRequest = 400,
        Conflict = 409,
        UnprocessableEntity = 422,
        PreconditionFailed = 412,
        MethodNotAllowed = 405,
        UnsupportedMediaType = 415,
        NotAcceptable = 406,
        RequestTimeout = 408,
        Gone = 410,
        LengthRequired = 411,
        PayloadTooLarge = 413,
        TooManyRequests = 429,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        LoopDetected = 508,
        NotExtended = 510,
        NetworkAuthenticationRequired = 511,
        NotModified = 304,
        PermanentRedirect = 308,
        TemporaryRedirect = 307,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        MultipleChoices = 300,
        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102,
        EarlyHints = 103,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        UseProxy = 305,
        SwitchProxy = 306
    }
}
