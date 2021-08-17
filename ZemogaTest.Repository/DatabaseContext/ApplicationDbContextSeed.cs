using System;
using System.Collections.Generic;
using System.Linq;
using ZemogaTest.Domain.Models;

namespace ZemogaTest.Repository.DatabaseContext
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "Public1",
                        Password = "Public1",
                        Role = "Public"
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "Writer1",
                        Password = "Writer1",
                        Role = "Writer"
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "Writer2",
                        Password = "Writer2",
                        Role = "Writer"
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "Editor1",
                        Password = "Editor1",
                        Role = "Editor"
                    }
                };

                applicationDbContext.Users.AddRange(users);
                applicationDbContext.SaveChanges();
            }
        }
    }
}
