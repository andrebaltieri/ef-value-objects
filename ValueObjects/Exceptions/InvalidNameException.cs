namespace ConsoleApp01.ValueObjects.Exceptions;

public class InvalidNameException : Exception
{
    public InvalidNameException() : base("Nome inválido")
    {
    }
}