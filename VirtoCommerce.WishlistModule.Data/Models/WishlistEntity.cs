using System;
using System.Linq;
using System.Collections.ObjectModel;
using VirtoCommerce.Platform.Core.Common;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Data.Models
{
    public class WishlistEntity : AuditableEntity
    {
        public WishlistEntity()
        {
            Items = new NullCollection<WishlistItemEntity>();
        }

        [StringLength(1024)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Type { get; set; }

        [StringLength(64)]
        public string MemberId { get; set; }

        [StringLength(64)]
        public string StoreId { get; set; }

        public ObservableCollection<WishlistItemEntity> Items { get; set; }

        public ObservableCollection<WishlistLinkEntity> Links { get; set; }

        public virtual WishlistEntity FromEntity(Wishlist wishlist, PrimaryKeyResolvingMap pkMap)
        {
            if (wishlist == null)
                throw new ArgumentNullException(nameof(wishlist));

            pkMap.AddPair(wishlist, this);

            Id = wishlist.Id;
            Name = wishlist.Name;
            Type = wishlist.Type;
            MemberId = wishlist.MemberId;
            StoreId = wishlist.StoreId;
            CreatedBy = wishlist.CreatedBy;
            CreatedDate = wishlist.CreatedDate;
            ModifiedBy = wishlist.ModifiedBy;
            ModifiedDate = wishlist.ModifiedDate;

            if (wishlist.Items != null)
            {
                Items = new ObservableCollection<WishlistItemEntity>(wishlist.Items.Select(x => AbstractTypeFactory<WishlistItemEntity>.TryCreateInstance().FromModel(x, pkMap)));
            }

            if (wishlist.Links != null)
            {
                Links = new ObservableCollection<WishlistLinkEntity>(wishlist.Links.Select(x => AbstractTypeFactory<WishlistLinkEntity>.TryCreateInstance().FromModel(x, pkMap)));
            }

            return this;
        }

        public virtual Wishlist ToModel(Wishlist wishlist)
        {
            if (wishlist == null)
                throw new ArgumentNullException(nameof(wishlist));

            wishlist.Id = Id;
            wishlist.Name = Name;
            wishlist.Type = wishlist.Type;
            wishlist.MemberId = wishlist.MemberId;
            wishlist.StoreId = wishlist.StoreId;
            wishlist.CreatedBy = CreatedBy;
            wishlist.CreatedDate = CreatedDate;
            wishlist.ModifiedBy = ModifiedBy;
            wishlist.ModifiedDate = ModifiedDate;

            wishlist.Items = Items.Select(x => x.ToModel(AbstractTypeFactory<WishlistItem>.TryCreateInstance())).ToArray();
            wishlist.Links = Links.Select(x => x.ToModel(AbstractTypeFactory<WishlistLink>.TryCreateInstance())).ToArray();

            return wishlist;
        }

        public virtual void Patch(WishlistEntity target)
        {
            target.Name = Name;
            target.Type = Type;
            target.MemberId = MemberId;
            target.StoreId = StoreId;

            if (!Items.IsNullCollection())
            {
                Items.Patch(target.Items, (sourceItem, targetItem) => sourceItem.Patch(targetItem));
            }

            if (!Links.IsNullCollection())
            {
                Links.Patch(target.Links, (sourceItem, targetItem) => sourceItem.Patch(targetItem));
            }
        }
    }
}
