using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.WishlistModule.Core.Model
{
    public class Wishlist : AuditableEntity
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string MemberId { get; set; }

        public string StoreId { get; set; }

        public IList<WishlistItem> Items { get; set; }

        public IList<WishlistLink> Links { get; set; }
    }
}
