using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly Func<IWishlistRepository> _wishListRepositoryFactory;

        public WishlistService(Func<IWishlistRepository> wishListRepositoryFactory)
        {
            _wishListRepositoryFactory = wishListRepositoryFactory;
        }

        public Wishlist[] GetByIds(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void RemoveByIds(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Wishlist[] lists)
        {
            throw new NotImplementedException();
        }
    }
}
