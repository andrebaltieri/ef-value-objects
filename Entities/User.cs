using ConsoleApp01.ValueObjects;
using ConsoleApp01.ValueObjects.Exceptions;
using SecureIdentity.Password;

namespace ConsoleApp01.Entities;

public class User : Entity
{
    #region Constructors

    protected User()
    {
    }

    public User(string email, string password = "")
    {
        if (email is null)
            throw new InvalidEmailException();

        if (string.IsNullOrEmpty(password))
            password = PasswordGenerator.Generate();

        Email = email;
        PasswordHash = PasswordHasher.Hash(password);
        Active = true;
        Tracker = new Tracker();
    }

    #endregion

    #region Properties

    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool Active { get; private set; }

    public bool CanLogIn => Active && Email.Verified;
    public string Notes { get; private set; } = string.Empty;
    public Tracker Tracker { get; }

    #endregion

    #region Methods

    public void Activate(string notes = "")
    {
        if (Email.Verified == false)
            throw new InvalidOperationException("Não é possível ativar um usuário com E-mail não verificado");

        Notes = notes;
        Active = true;
        Tracker.Update();
    }

    public void Inactivate(string notes = "", bool requireEmailVerification = false)
    {
        Notes = notes;
        Active = false;

        if (requireEmailVerification)
            Email.Expire();

        Tracker.Update();
    }

    public void VerifyEmail(string verificationCode)
    {
        Email.Verify(verificationCode);
        Tracker.Update();
    }

    public void GenerateNewEmailVerificationCode()
    {
        Email.GenerateNewEmailVerificationCode();
        Tracker.Update();
    }

    public void ChangeUsername(Email email)
    {
        Email = email;
        Email.Expire();
        Tracker.Update();
    }

    public void ChangePassword(string password, bool requireEmailVerification = false)
    {
        PasswordHash = PasswordHasher.Hash(password);

        if (requireEmailVerification)
            Email.Expire();

        Tracker.Update();
    }

    public string ResetPassword(bool requireEmailVerification = false)
    {
        var password = PasswordGenerator.Generate();
        PasswordHash = PasswordHasher.Hash(password);

        if (requireEmailVerification)
            Email.Expire();

        Tracker.Update();

        return password;
    }

    #endregion

    #region Overloads

    public static implicit operator string(User user) => user.Email;
    public override string ToString() => Email;

    #endregion
}