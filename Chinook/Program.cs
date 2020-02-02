using System;
using Chinook.Data;

namespace Chinook
{
    class Program
    {
        static void Main()
        {
            // Scaffold-DbContext 'Data Source=Chinook.db' Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -ContextDir Data -Force

            var db = new ChinookContext();
            foreach (var artist in db.Artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}
