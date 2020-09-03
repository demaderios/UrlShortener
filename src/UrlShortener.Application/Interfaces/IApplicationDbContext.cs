using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ShortUrl> ShortUrls { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
