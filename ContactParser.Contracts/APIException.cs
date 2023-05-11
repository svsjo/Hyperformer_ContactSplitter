namespace ContactParser.Contracts;

public class ApiException : Exception
{
    public ApiException(): base("Could not reach API")
    {
        
    }
}

