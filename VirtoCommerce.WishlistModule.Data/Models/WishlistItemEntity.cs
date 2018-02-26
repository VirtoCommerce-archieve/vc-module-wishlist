using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.WishlistModule.Core.Model;

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

        public virtual WishlistItemEntity FromModel(WishlistItem wishlistItem, PrimaryKeyResolvingMap pkMap)
        {
            if (wishlistItem == null)
                throw new ArgumentNullException(nameof(wishlistItem));

            pkMap.AddPair(wishlistItem, this);

            Id = wishlistItem.Id;
            ProductId = wishlistItem.ProductId;
            ProductSku = wishlistItem.ProductSku;
            ProductName = wishlistItem.ProductName;
            ProductType = wishlistItem.ProductType;
            ImageUrl = wishlistItem.ImageUrl;
            Quantity = wishlistItem.Quantity;
            CreatedBy = wishlistItem.CreatedBy;
            CreatedDate = wishlistItem.CreatedDate;
            ModifiedBy = wishlistItem.ModifiedBy;
            ModifiedDate = wishlistItem.ModifiedDate;

            return this;
        }

        public virtual WishlistItem ToModel(WishlistItem wishlistItem)
        {
            if (wishlistItem == null)
                throw new ArgumentNullException(nameof(wishlistItem));

            wishlistItem.Id = Id;
            wishlistItem.ProductId = ProductId;
            wishlistItem.ProductSku = ProductSku;
            wishlistItem.ProductName = ProductName;
            wishlistItem.ProductType = ProductType;
            wishlistItem.ImageUrl = ImageUrl;
            wishlistItem.Quantity = Quantity;
            wishlistItem.CreatedBy = CreatedBy;
            wishlistItem.CreatedDate = CreatedDate;
            wishlistItem.ModifiedBy = ModifiedBy;
            wishlistItem.ModifiedDate = ModifiedDate;

            return wishlistItem;
        }

        public virtual void Patch(WishlistItemEntity target)
        {
            target.ProductId = ProductId;
            target.ProductSku = ProductSku;
            target.ProductName = ProductName;
            target.ProductType = ProductType;
            target.ImageUrl = ImageUrl;
            target.Quantity = Quantity;
        }
    }
}
