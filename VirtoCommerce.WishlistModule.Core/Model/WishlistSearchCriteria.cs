using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.WishlistModule.Core.Model
{
    public class WishlistSearchCriteria : SearchCriteriaBase
    {
        public string Name { get; set; }

        public string StoreId { get; set; }

        public string MemberId { get; set; }
    }
}
