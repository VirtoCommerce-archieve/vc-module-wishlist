using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Core.Services
{
    public interface IWishlistLinkSearchService
    {
        GenericSearchResult<WishlistLink> Search(WishlistLinkSearchCriteria criteria);
    }
}
