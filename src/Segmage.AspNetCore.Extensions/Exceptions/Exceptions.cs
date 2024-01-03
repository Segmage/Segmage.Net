using System.ComponentModel.DataAnnotations;

namespace Segmage.AspNetCore.Extensions.Exceptions;

public class SessionNullException:ValidationException
{
    public SessionNullException(string message):base(message) { }
}