using LuxStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxStore.DataAccessLayer.DataSeed
{
    public static class SeedData
    {
        public static void AppUserSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(

                new AppUser
                {
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@luxstore.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Test",
                    SurName = "Admin",
                    Password = "1234",
                }
            );
        }

        public static void CategorySeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Name = "Roman",
                    ParentId = 0,
                    IsActive = true,
                    IsTopMenu = true,
                    OrderNo = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Hikaye",
                    ParentId = 0,
                    IsActive = true,
                    IsTopMenu = true,
                    OrderNo = 2
                }
            );
        }
    }
}