using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.WishlistModule.Data.Models
{
    public class WishlistItemEntity : AuditableEntity
    {
        [Required]
        [StringLength(64)]
        public string ProductId { get; set; }

        [StringLength(64)]
        public string ProductSku { get; set; }

        [StringLength(256)]
        public string ProductName { get; set; }

        [StringLength(64)]
        public string ProductType { get; set; }

        [StringLength(1028)]
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        [StringLength(64)]
        public string ListId { get; set; }

        public WishlistEntity List { get; set; }
    }
}
