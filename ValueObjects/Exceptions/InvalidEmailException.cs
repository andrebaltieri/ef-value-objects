namespace ConsoleApp01.ValueObjects.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException() : base("E-mail inválido")
    {
    }
}