using System.Text.RegularExpressions;
using ConsoleApp01.ValueObjects.Exceptions;

namespace ConsoleApp01.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        if (string.IsNullOrEmpty(address) || address.Length < 5)
            throw new InvalidEmailException();

        Address = address.ToLower().Trim();
        const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        if (!Regex.IsMatch(address, pattern))
            throw new InvalidEmailException();

        Verified = false;
        VerificationCode = Guid.NewGuid().ToString();
        VerificationCodeExpireDate = DateTime.UtcNow.AddHours(8);
    }

    public string Address { get; private set; }
    public bool Verified { get; private set; }
    public string VerificationCode { get; private set; }
    public DateTime VerificationCodeExpireDate { get; private set; }

    public void Verify(string verificationCode)
    {
        if (verificationCode != VerificationCode)
            throw new ArgumentException("Código de ativação inválido");

        if (DateTime.UtcNow > VerificationCodeExpireDate)
            throw new ArgumentException("Código de ativação expirado");

        Verified = true;
    }

    public void GenerateNewEmailVerificationCode()
    {
        Verified = false;
        VerificationCode = Guid.NewGuid().ToString();
        VerificationCodeExpireDate = DateTime.UtcNow.AddHours(8);
    }

    public void Expire() => Verified = false;

    public static implicit operator string(Email email) => email.Address;

    public static implicit operator Email(string address) => new(address);

    public override string ToString() => Address;
}