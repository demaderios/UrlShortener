using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Common;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Identity;

namespace UrlShortener.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, 
            ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.sCreatedBy = _currentUserService.UserId;
                        entry.Entity.dtCreated = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.sLastModifiedBy = _currentUserService.UserId;
                        entry.Entity.dtLastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
