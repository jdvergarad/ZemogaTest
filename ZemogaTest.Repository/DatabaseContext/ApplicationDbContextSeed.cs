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
            var writer1 = new User
            {
                Id = Guid.NewGuid(),
                Username = "Writer1",
                Password = "Writer1",
                Role = "Writer"
            };

            var guidWriter1 = Guid.NewGuid();
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

                users.Add(writer1);

                applicationDbContext.Users.AddRange(users);
                applicationDbContext.SaveChanges();
            }

            if (!applicationDbContext.Posts.Any())
            {
                var posts = new List<Post>
                {
                    new Post
                    {
                        Id = Guid.NewGuid(),
                        AuthorUserName = "Writer1",
                        Comments = new List<Comment>(),
                        Title = "Title1",
                        Content = "Content1",
                        Status = PostStatus.Published,
                        StatusMessage = PostStatus.Published.ToString(),
                        PublishedDate = DateTime.Now.AddDays(-1),
                        CreatedDate = DateTime.Now.AddDays(-2),
                        ModifiedDate = DateTime.Now.AddDays(-1),
                        Author = writer1
                    }
                };

                applicationDbContext.Posts.AddRange(posts);
                applicationDbContext.SaveChanges();
            }
        }
    }
}
