using Maway.Data;
using Maway.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Maway.WebApi.Middleware
{
    public static class DatabaseContextMiddleware
    {
        public static void SeedDb(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices
           .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                //if (!context.AttributeTypeDictionary.Any())
                //{
                //    context.AttributeTypeDictionary.AddRange(new AttributeTypeDictionary[]
                //    {
                //        new AttributeTypeDictionary{ Key = "Numeric"},
                //        new AttributeTypeDictionary{ Key = "Boolean"},
                //        new AttributeTypeDictionary{ Key = "Text"},
                //        new AttributeTypeDictionary{ Key = "Numeric"},
                //        new AttributeTypeDictionary{ Key = "Link"}
                //    });
                //}

                //if (!context.Attributes.Any())k

               

                context.SaveChangesAsync();
            }
        }
    }
}
