using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.WishlistModule.Core.Model
{
    public class WishlistLink : AuditableEntity
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string OwnerName { get; set; }

        public string OwnerId { get; set; }

        public string MemberId { get; set; }

        public string WishlistId { get; set; }

        public WishlistPermission Permission { get; set; }
    }
}
