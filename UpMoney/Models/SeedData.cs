using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace UpMoney.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new MvcMovieContext(
            //    serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            //{
            //    // Look for any movies.
            //    if (context.Movie.Any())
            //    {
            //        return;   // DB has been seeded
            //    }

            //    context.Movie.AddRange(
            //         new Cliente
            //         {
            //             Title = "When Harry Met Sally",
            //             ReleaseDate = DateTime.Parse("1989-1-11"),
            //             Genre = "Romantic Comedy",
            //             Price = 7.99M
            //         }                   

                
            //    );
                /*context.SaveChanges();*/
            }
        }
    }



