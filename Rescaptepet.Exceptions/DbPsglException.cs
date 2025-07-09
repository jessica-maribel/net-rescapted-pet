using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Exceptions;

public class DbPsglException : Exception
{
    public DbPsglException()
    {
    }

    public DbPsglException(string message) : base(message)
    {
    }

    public DbPsglException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected DbPsglException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
