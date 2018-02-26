using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.WishlistModule.Core.Model
{
    public class WishlistLinkSearchCriteria : SearchCriteriaBase
    {
        public string Name { get; set; }

        public string OwnerId { get; set; }

        public string MemberId { get; set; }
    }
}
