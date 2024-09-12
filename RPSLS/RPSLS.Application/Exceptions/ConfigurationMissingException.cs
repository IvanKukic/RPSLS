namespace RPSLS.Application.Exceptions;

public class ConfigurationMissingException : Exception
{
    public ConfigurationMissingException(string propertyName) : base("Configuration property not found: " + propertyName)
    {

    }
}
