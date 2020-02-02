using System;
using ChinookApp.Data;

namespace ChinookApp
{
    class Program
    {
        static void Main()
        {
            // Scaffold-DbContext 'Data Source=(localdb)\ProjectsV13;Initial Catalog=ChinookDatabase' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Force

            var db = new ChinookDatabaseContext();
            foreach (var artist in db.Artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}
