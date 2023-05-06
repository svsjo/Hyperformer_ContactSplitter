namespace ContactParser.Contracts;

public class APIException : Exception
{
    public APIException(): base("Could not reach API")
    {
        
    }
}

