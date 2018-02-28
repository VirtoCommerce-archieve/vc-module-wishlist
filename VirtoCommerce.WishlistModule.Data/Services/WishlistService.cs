using System;
using System.Linq;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Models;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistService : ServiceBase, IWishlistService
    {
        private readonly Func<IWishlistRepository> _wishListRepositoryFactory;

        public WishlistService(Func<IWishlistRepository> wishListRepositoryFactory)
        {
            _wishListRepositoryFactory = wishListRepositoryFactory;
        }

        public Wishlist[] GetByIds(string[] ids)
        {
            using (var repository = _wishListRepositoryFactory())
            {
                return repository.GetWishlistsByIds(ids)
                    .Select(x => x.ToModel(AbstractTypeFactory<Wishlist>.TryCreateInstance())).ToArray();
            }
        }

        public void RemoveByIds(string[] ids)
        {
            using (var repository = _wishListRepositoryFactory())
            {
                repository.RemoveWishlistsByIds(ids);
                CommitChanges(repository);
            }
        }

        public void SaveOrUpdate(Wishlist[] lists)
        {
            var pkMap = new PrimaryKeyResolvingMap();
            using (var repository = _wishListRepositoryFactory())
            using (var changeTracker = GetChangeTracker(repository))
            {
                var existingEntities = repository.GetWishlistsByIds(lists.Select(t => t.Id).ToArray());
                foreach (var list in lists)
                {
                    var sourceEntity = AbstractTypeFactory<WishlistEntity>.TryCreateInstance();
                    if (sourceEntity != null)
                    {
                        sourceEntity = sourceEntity.FromModel(list, pkMap);
                        var targetEntity = existingEntities.FirstOrDefault(x => x.Id == list.Id);
                        if (targetEntity != null)
                        {
                            changeTracker.Attach(targetEntity);
                            sourceEntity.Patch(targetEntity);
                        }
                        else
                        {
                            repository.Add(sourceEntity);
                        }
                    }
                }

                CommitChanges(repository);
                pkMap.ResolvePrimaryKeys();
            }
        }
    }
}
