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
    public class WishlistLinkService : ServiceBase, IWishlistLinkService
    {
        private readonly Func<IWishlistRepository> _wishlistRepositoryFactory;

        public WishlistLinkService(Func<IWishlistRepository> wishlistRepositoryFactory)
        {
            _wishlistRepositoryFactory = wishlistRepositoryFactory;
        }

        public WishlistLink[] GetByIds(string[] ids)
        {
            using (var repository = _wishlistRepositoryFactory())
            {
                return repository.GetWishlistLinksByIds(ids)
                    .Select(x=>x.ToModel(AbstractTypeFactory<WishlistLink>.TryCreateInstance())).ToArray();
            }
        }

        public void RemoveByIds(string[] ids)
        {
            using (var repository = _wishlistRepositoryFactory())
            {
                repository.RemoveWishlistLinksByIds(ids);
                CommitChanges(repository);
            }
        }

        public void SaveOrUpdate(WishlistLink[] listLinks)
        {
            var pkMap = new PrimaryKeyResolvingMap();
            using (var repository = _wishlistRepositoryFactory())
            using (var changeTracker = GetChangeTracker(repository))
            {
                var existingEntities = repository.GetWishlistLinksByIds(listLinks.Select(t => t.Id).ToArray());
                foreach (var link in listLinks)
                {
                    var sourceEntity = AbstractTypeFactory<WishlistLinkEntity>.TryCreateInstance();
                    if (sourceEntity != null)
                    {
                        sourceEntity = sourceEntity.FromModel(link, pkMap);
                        var targetEntity = existingEntities.FirstOrDefault(x => x.Id == link.Id);
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
