using System.Linq;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.WishlistModule.Data.Models;

namespace VirtoCommerce.WishlistModule.Data.Repositories
{
    public interface IWishlistRepository : IRepository
    {
        IQueryable<WishlistEntity> Wishlists { get; }

        IQueryable<WishlistLinkEntity> WishlistLinks { get; }

        WishlistEntity[] GetWishlistsByIds(string[] ids);

        void RemoveWishlistsByIds(string[] ids);

        WishlistLinkEntity[] GetWishlistLinksByIds(string[] ids);

        void RemoveWishlistLinksByIds(string[] ids);
    }
}
