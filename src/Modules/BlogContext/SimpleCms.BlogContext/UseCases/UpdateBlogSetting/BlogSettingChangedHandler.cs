﻿using SimpleCms.Core;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCms.BlogContext.Core.Domain;
using SimpleCms.BlogContext.Infrastructure;

namespace SimpleCms.BlogContext.UseCases.UpdateBlogSetting
{
    public class BlogSettingChangedHandler : IAsyncNotificationHandler<BlogSettingChanged>
    {
        private readonly BlogDbContext _dbContext;

        public BlogSettingChangedHandler(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(BlogSettingChanged notification)
        {
            var blodSetting = await _dbContext.Set<BlogSetting>().FirstOrDefaultAsync(x => x.BlogSettingId == notification.OldBlogSettingId);
            if (blodSetting == null)
            {
                throw new CoreException($"Could not found the BlogSetting #{notification.OldBlogSettingId}");
            }
            _dbContext.Entry(blodSetting).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}