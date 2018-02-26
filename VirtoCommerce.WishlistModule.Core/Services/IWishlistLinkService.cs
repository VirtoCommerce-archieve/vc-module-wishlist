using VirtoCommerce.WishlistModule.Core.Model;

namespace VirtoCommerce.WishlistModule.Core.Services
{
    public interface IWishlistLinkService
    {
        void SaveOrUpdate(WishlistLink[] lists);
        WishlistLink[] GetByIds(string[] ids);
        void RemoveByIds(string[] ids);
    }
}
