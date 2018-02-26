using System;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Models;
using VirtoCommerce.WishlistModule.Data.Repositories;

namespace VirtoCommerce.WishlistModule.Data.Services
{
    public class WishlistLinkSearchService : IWishlistLinkSearchService
    {
        private readonly Func<IWishlistRepository> _wishlistRepositoryFactory;

        public WishlistLinkSearchService(Func<IWishlistRepository> wishlistRepositoryFactory)
        {
            _wishlistRepositoryFactory = wishlistRepositoryFactory;
        }

        public GenericSearchResult<WishlistLink> Search(WishlistLinkSearchCriteria criteria)
        {
            using (var repository = _wishlistRepositoryFactory())
            {
                var query = GetWishlistQuery(repository, criteria);

                var sortInfos = criteria.SortInfos;
                if (sortInfos.IsNullOrEmpty())
                {
                    sortInfos = new[] { new SortInfo { SortColumn = ReflectionUtility.GetPropertyName<WishlistLink>(t => t.CreatedDate), SortDirection = SortDirection.Descending } };
                }

                query = query.OrderBySortInfos(sortInfos);
                var totalCount = query.Count();

                var ids = query.Skip(criteria.Skip).Take(criteria.Take).Select(x => x.Id).ToArray();
                var results = repository.GetWishlistLinksByIds(ids).Select(t => t.ToModel(AbstractTypeFactory<WishlistLink>.TryCreateInstance())).ToArray();

                var result = new GenericSearchResult<WishlistLink>()
                {
                    TotalCount = totalCount,
                    Results = results.AsQueryable().OrderBySortInfos(sortInfos).ToList()
                };

                return result;
            }
        }

        protected virtual IQueryable<WishlistLinkEntity> GetWishlistQuery(IWishlistRepository repository, WishlistLinkSearchCriteria criteria)
        {
            var query = repository.WishlistLinks;

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(x => x.Name == criteria.Name);
            }

            if (!string.IsNullOrEmpty(criteria.MemberId))
            {
                query = query.Where(x => x.MemberId == criteria.MemberId);
            }

            if (!string.IsNullOrEmpty(criteria.OwnerId))
            {
                query = query.Where(x => criteria.OwnerId == x.OwnerId);
            }

            return query;
        }
    }
}
