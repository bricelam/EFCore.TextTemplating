using System;
using ChinookApp.Data;

namespace ChinookApp
{
    class Program
    {
        static void Main()
        {
            using var db = new ChinookDatabaseContext();

            foreach (var artist in db.Artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}
