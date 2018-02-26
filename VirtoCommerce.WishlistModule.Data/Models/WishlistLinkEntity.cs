using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

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
    }
}
