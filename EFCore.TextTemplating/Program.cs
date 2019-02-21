using System;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating
{
    class Program
    {
        static void Main()
        {
            // Scaffold-DbContext 'Data Source=Chinook.db' Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models

            var db = new ChinookContext();
            foreach (var artist in db.Artist)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}
