using System;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistLinkSearchService : IWishlistLinkSearchService
    {
        private readonly Func<IWishlistRepository> _wishlistRepositoryFactory;

        public WishlistLinkSearchService(Func<IWishlistRepository> wishlistRepositoryFactory)
        {
            _wishlistRepositoryFactory = wishlistRepositoryFactory;
        }

        public GenericSearchResult<WishlistLink> Search(WishlistLinkSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
