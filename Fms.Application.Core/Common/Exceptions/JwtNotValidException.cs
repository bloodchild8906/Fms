using System;
using Microsoft.Extensions.Logging;

namespace Fms.Application.Core.Common.Exceptions;

public class JwtNotValidException:Exception
{
    public JwtNotValidException():base("the Jwt Token Supplied is not valid")
    {
    }
}