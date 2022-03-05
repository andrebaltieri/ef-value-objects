using ConsoleApp01.ValueObjects.Exceptions;

namespace ConsoleApp01.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        if (firstName is null || lastName is null)
            throw new InvalidNameException();

        FirstName = firstName.Trim();
        LastName = lastName.Trim();

        if (FirstName.Length < 3 || LastName.Length < 3)
            throw new InvalidNameException();
    }

    public string FirstName { get; }
    public string LastName { get; }

    public static implicit operator string(Name name) => $"{name.FirstName} {name.LastName}";

    public static implicit operator Name(string name)
    {
        if (name is null)
            throw new InvalidNameException();

        name = name.Trim();
        var index = name.IndexOf(" ", StringComparison.Ordinal);

        if (index <= 0)
            throw new InvalidNameException();

        try
        {
            var first = name.Substring(0, index);
            var last = name.Substring(index + 1, name.Length - (index + 1));
            return new Name(first, last);
        }
        catch
        {
            throw new InvalidNameException();
        }
    }

    public override string ToString() => $"{FirstName} {LastName}";
}