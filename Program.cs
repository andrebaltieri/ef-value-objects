// See https://aka.ms/new-console-template for more information

using ConsoleApp01;
using ConsoleApp01.Entities;

// var user = new User("andre@balta.io");

using var context = new AppDbContext();
// context.Users.Add(user);
// context.SaveChanges();

// var user = context.Users.FirstOrDefault(x => x.Id == new Guid("c8b3e778-eab1-4b0c-9702-d85b248a0bb0"));
// user?.VerifyEmail("6684c3cc-448c-4d9d-bed8-bcf35db17978");
// context.Update(user);
// context.SaveChanges();

foreach (var user in context.Users)
{
    Console.WriteLine(user.Email);
    Console.WriteLine(user.Email.Verified);
    Console.WriteLine(user.Email.VerificationCode);
    Console.WriteLine(user.Email.VerificationCodeExpireDate);
    Console.WriteLine(user.Tracker.CreatedAt);
    Console.WriteLine(user.Tracker.UpdatedAt);
}

Console.WriteLine("OK");