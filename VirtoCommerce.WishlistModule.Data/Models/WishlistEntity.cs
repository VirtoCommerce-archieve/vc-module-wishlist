using System.Collections.ObjectModel;
using VirtoCommerce.Platform.Core.Common;
using System.ComponentModel.DataAnnotations;

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
    }
}
