using MySqlConnector;
using System.Data.Common;
using test;
using testconnection;

internal class Program
{
    private static void Main(string[] args)
    {
        using var db = new AppDbContext();
        var users = db.departments.ToList();

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.dept_id}, Name: {user.dept_code}, Email: {user.dept_name}");
        }
    }
}