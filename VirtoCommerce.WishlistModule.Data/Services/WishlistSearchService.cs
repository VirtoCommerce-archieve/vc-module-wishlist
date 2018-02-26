using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistSearchService : IWishlistSearchService
    {
        private readonly Func<IWishlistRepository> _wishListRepositoryFactory;

        public WishlistSearchService(Func<IWishlistRepository> wishListRepositoryFactory)
        {
            _wishListRepositoryFactory = wishListRepositoryFactory;
        }

        public GenericSearchResult<Wishlist> Search(WishlistSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
