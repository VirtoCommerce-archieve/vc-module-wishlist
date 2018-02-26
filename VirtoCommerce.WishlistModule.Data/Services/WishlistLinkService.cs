using System;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistLinkService : IWishlistLinkService
    {
        private readonly Func<IWishlistRepository> _wishlistRepositoryFactory;

        public WishlistLinkService(Func<IWishlistRepository> wishlistRepositoryFactory)
        {
            _wishlistRepositoryFactory = wishlistRepositoryFactory;
        }

        public WishlistLink[] GetByIds(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void RemoveByIds(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(WishlistLink[] lists)
        {
            throw new NotImplementedException();
        }
    }
}
