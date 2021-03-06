﻿using SimpleCms.BlogContext.Core.Domain;
using SimpleCms.BlogContext.Infrastructure;
using SimpleCms.Core.Helpers;
using System;
using System.Threading.Tasks;

namespace SimpleCms.BlogContext.Migrator
{
    public static class BlogContextSeeder
    {
        public static async Task Seed(BlogDbContext dbContext)
        {
            var defaultPost = Core.Domain.Blog.CreateInstance(
                    new Guid("34c96712-2cdf-4e79-9e2f-768cb68dd552"),
                    "Blog for Emre",
                    "emre@emrekarahan.work")
                .ChangeDescription("Blog for emre's description")
                .ChangeSetting(new BlogSetting(IdHelper.GenerateId(), 10, 5, true));

            await dbContext.Set<Core.Domain.Blog>().AddAsync(defaultPost);

            for (var i = 1; i <= 1; i++)
            {
                var blog = Core.Domain.Blog.CreateInstance(
                        new Guid("5b1fa7c2-f814-47f2-a2f3-03866f978c49"),
                        $"Blog {i} - Root",
                        "root@emrekarahan.work")
                    .ChangeDescription($"Blog {i}'s description")
                    .ChangeSetting(new BlogSetting(IdHelper.GenerateId(), 10, 5, true));

                await dbContext.Set<Core.Domain.Blog>().AddAsync(blog);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}