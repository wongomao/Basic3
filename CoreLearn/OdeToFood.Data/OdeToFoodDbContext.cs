using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}


/*
PS D:\dv\src\Basic3\CoreLearn\OdeToFood.Data> dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 2.1.8-servicing-32085 initialized 'OdeToFoodDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: MaxPoolSize=128
Provider name: Microsoft.EntityFrameworkCore.SqlServer
Database name: OdeToFood
Data source: (localdb)\v11.0
Options: MaxPoolSize=128
PS D:\dv\src\Basic3\CoreLearn\OdeToFood.Data>

PS D:\dv\src\Basic3\CoreLearn\OdeToFood.Data> dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 2.1.8-servicing-32085 initialized 'OdeToFoodDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: MaxPoolSize=128
Done. To undo this action, use 'ef migrations remove'
PS D:\dv\src\Basic3\CoreLearn\OdeToFood.Data>
PS D:\dv\src\Basic3\CoreLearn\OdeToFood.Data> dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj

*/
