using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.WishlistModule.Core.Model
{
    public class WishlistItem : AuditableEntity
    {
        public string ProductId { get; set; }

        public string ProductSku { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public string ListId { get; set; }
    }
}
