namespace ConsoleApp01.ValueObjects;

public record Error
{
    public Error(string value)
    {
        Key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        Value = value;
    }

    public Error(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; } = string.Empty;
    public string Value { get; } = string.Empty;
}