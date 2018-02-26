using System;
using System.Linq;
using System.Data.Entity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.WishlistModule.Data.Models;

namespace VirtoCommerce.WishlistModule.Data.Repositories
{
    public class WishlistRepositoryImpl : EFRepositoryBase, IWishlistRepository
    {
        public WishlistRepositoryImpl() : base()
        {
        }

        public WishlistRepositoryImpl(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, null, interceptors)
        {
            Database.SetInitializer<WishlistRepositoryImpl>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishlistEntity>().ToTable("Wishlist").HasKey(x => x.Id).Property(x => x.Id);

            #region Items

            modelBuilder.Entity<WishlistItemEntity>().ToTable("WishlistItem").HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<WishlistItemEntity>()
                .HasRequired(x => x.List)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ListId).WillCascadeOnDelete(true);

            #endregion

            #region Links

            modelBuilder.Entity<WishlistLinkEntity>().ToTable("WishlistLink").HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<WishlistLinkEntity>()
                .HasRequired(x => x.List)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.ListId).WillCascadeOnDelete(true);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<WishlistEntity> Wishlists => GetAsQueryable<WishlistEntity>();

        public IQueryable<WishlistLinkEntity> WishlistLinks => GetAsQueryable<WishlistLinkEntity>();

        public IQueryable<WishlistItemEntity> WishlistItems => GetAsQueryable<WishlistItemEntity>();

        public WishlistLinkEntity[] GetWishlistLinksByIds(string[] ids)
        {
            return WishlistLinks.Where(x => ids.Contains(x.Id)).ToArray();
        }

        public WishlistEntity[] GetWishlistsByIds(string[] ids)
        {
            return Wishlists
                .Include(x => x.Items)
                .Include(x => x.Links)
                .Where(x => ids.Contains(x.Id))
                .ToArray();
        }

        public void RemoveWishlistLinksByIds(string[] ids)
        {
            foreach (var entity in GetWishlistLinksByIds(ids))
            {
                Remove(entity);
            }
        }

        public void RemoveWishlistsByIds(string[] ids)
        {
            foreach (var entity in GetWishlistsByIds(ids))
            {
                Remove(entity);
            }
        }
    }
}
