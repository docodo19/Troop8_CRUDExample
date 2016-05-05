using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CoolDesk.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();

            if (!db.Movies.Any())
            {
                db.Movies.AddRange(
                    new Movie { Title = "Star Wars", Director = "Lucas"},
                    new Movie { Title = "Momento", Director = "Nolan"},
                    new Movie { Title = "King Kong", Director = "Jackson"}
                );
                db.SaveChanges();
            }
        }
    }
}
