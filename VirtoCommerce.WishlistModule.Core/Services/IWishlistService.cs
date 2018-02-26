using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Core.Services
{
    public interface IWishlistService
    {
        void SaveOrUpdate(Wishlist[] lists);
        Wishlist[] GetByIds(string[] ids);
        void RemoveByIds(string[] ids);
    }
}
