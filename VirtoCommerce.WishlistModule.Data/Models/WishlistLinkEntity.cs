using System;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Data.Models
{
    public class WishlistLinkEntity : AuditableEntity
    {
        [StringLength(1024)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Type { get; set; }

        [StringLength(256)]
        public string OwnerName { get; set; }

        [StringLength(64)]
        public string OwnerId { get; set; }

        [StringLength(64)]
        public string MemberId { get; set; }

        [StringLength(64)]
        public string Permission { get; set; }

        public string ListId { get; set; }
        public WishlistEntity List { get; set; }

        public virtual WishlistLinkEntity FromModel(WishlistLink wishlistLink, PrimaryKeyResolvingMap pkMap)
        {
            if (wishlistLink == null)
                throw new ArgumentNullException(nameof(wishlistLink));

            pkMap.AddPair(wishlistLink, this);

            Id = wishlistLink.Id;
            Name = wishlistLink.Name;
            Type = wishlistLink.Type;
            OwnerName = wishlistLink.OwnerName;
            OwnerId = wishlistLink.OwnerId;
            MemberId = wishlistLink.MemberId;
            Permission = wishlistLink.Permission.ToString();
            CreatedBy = wishlistLink.CreatedBy;
            CreatedDate = wishlistLink.CreatedDate;
            ModifiedBy = wishlistLink.ModifiedBy;
            ModifiedDate = wishlistLink.ModifiedDate;

            return this;
        }

        public virtual WishlistLink ToModel(WishlistLink wishlistLink)
        {
            if (wishlistLink == null)
                throw new ArgumentNullException(nameof(wishlistLink));

            wishlistLink.Id = Id;
            wishlistLink.Name = Name;
            wishlistLink.Type = Type;
            wishlistLink.OwnerName = OwnerName;
            wishlistLink.OwnerId = OwnerId;
            wishlistLink.MemberId = MemberId;
            wishlistLink.Permission = EnumUtility.SafeParse(Permission, WishlistPermission.Readonly);
            wishlistLink.CreatedBy = CreatedBy;
            wishlistLink.CreatedDate = CreatedDate;
            wishlistLink.ModifiedBy = ModifiedBy;
            wishlistLink.ModifiedDate = ModifiedDate;

            return wishlistLink;
        }

        public virtual void Patch(WishlistLinkEntity target)
        {
            target.Id = Id;
            target.Name = Name;
            target.Type = Type;
            target.OwnerName = OwnerName;
            target.OwnerId = OwnerId;
            target.MemberId = MemberId;
            target.Permission = Permission;
        }
    }
}
