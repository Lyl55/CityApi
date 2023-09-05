using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<CityEntity> CityEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
