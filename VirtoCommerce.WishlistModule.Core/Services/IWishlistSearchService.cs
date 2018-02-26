using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Core.Services
{
    public interface IWishlistSearchService
    {
        GenericSearchResult<Wishlist> Search(WishlistSearchCriteria criteria);
    }
}
