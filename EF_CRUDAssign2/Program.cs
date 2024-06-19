using Core.Entities;
using Core.Interface;
using EF_CRUDAssign2;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main(string[] args)
    {

        TestDatabase();

    }
    public static void TestDatabase()
    {
        var repo = new Repo();
        while (true)
        {
            Console.WriteLine("List of all Users");
            ListUser();
            Console.WriteLine("Enter 1 To Insert New User, " +
                "2 To Update A User," +
                " 3 To Delete A User," +
                "4 To Exit");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter Details");
                var user = new User()
                {
                    Name = ReadUser("Name :", null),
                    PhoneNumber = ReadUser("Phone Number :", null),
                    EmailAddress = ReadUser("Email Address :", null),
                };
                repo.Create(user);

                 
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter ID to be Updated : ");
                int id = int.Parse(Console.ReadLine());
                var updatedUser = repo.Read<User>(id);
                if (updatedUser != null)
                {
                    updatedUser.Name = ReadUser("Name :", updatedUser.Name);
                    updatedUser.PhoneNumber = ReadUser("Phone Number :", updatedUser.PhoneNumber);
                    updatedUser.EmailAddress = ReadUser("Email Address :", updatedUser.EmailAddress);
                    repo.Update(updatedUser);

                }

            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter ID to be deleted");
                int id = int.Parse(Console.ReadLine());
                repo.Delete<User>(id);

            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter 1,2,3 or 4");
            }
        }

    }
    public static string ReadUser(String writeLine, string defaultData)
    {
        Console.Write(writeLine);
        var num = Console.ReadLine();
        if (!string.IsNullOrEmpty(num))
        {
            return num.Trim();
        }
        else
        {
            return defaultData;
        }

    }
    public static void ListUser()
    {
        var dbContext = new BloggingContext();
        var users = dbContext.Users.Where(u => !u.IsDeleted).ToList();
        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.UserId}, Name: {user.Name}, Email: {user.EmailAddress}, Phone: {user.PhoneNumber}");
            }
        }
    }


}
