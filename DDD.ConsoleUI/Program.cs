using System;

namespace DDD.ConsoleUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ApplicationDbContextFactory();
            using (var ctx= factory.CreateDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                Console.WriteLine("Database created !!");
            }
        }
    }
}
