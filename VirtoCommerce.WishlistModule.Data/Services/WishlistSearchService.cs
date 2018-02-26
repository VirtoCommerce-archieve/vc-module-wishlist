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
    public class WishlistSearchService : IWishlistSearchService
    {
        private readonly Func<IWishlistRepository> _wishListRepositoryFactory;

        public WishlistSearchService(Func<IWishlistRepository> wishListRepositoryFactory)
        {
            _wishListRepositoryFactory = wishListRepositoryFactory;
        }

        public GenericSearchResult<Wishlist> Search(WishlistSearchCriteria criteria)
        {
            using (var repository = _wishListRepositoryFactory())
            {
                var query = GetWishlistQuery(repository, criteria);

                var sortInfos = criteria.SortInfos;
                if (sortInfos.IsNullOrEmpty())
                {
                    sortInfos = new[] { new SortInfo { SortColumn = ReflectionUtility.GetPropertyName<Wishlist>(t => t.CreatedDate), SortDirection = SortDirection.Descending } };
                }

                query = query.OrderBySortInfos(sortInfos);
                var totalCount = query.Count();

                var ids = query.Skip(criteria.Skip).Take(criteria.Take).Select(x => x.Id).ToArray();
                var results = repository.GetWishlistsByIds(ids).Select(t => t.ToModel(AbstractTypeFactory<Wishlist>.TryCreateInstance())).ToArray();

                var result = new GenericSearchResult<Wishlist>()
                {
                    TotalCount = totalCount,
                    Results = results.AsQueryable().OrderBySortInfos(sortInfos).ToList()
                };
                return result;
            }
        }

        protected virtual IQueryable<WishlistEntity> GetWishlistQuery(IWishlistRepository repository, WishlistSearchCriteria criteria)
        {
            var query = repository.Wishlists;

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(x => x.Name == criteria.Name);
            }

            if (!string.IsNullOrEmpty(criteria.MemberId))
            {
                query = query.Where(x => x.MemberId == criteria.MemberId);
            }

            if (!string.IsNullOrEmpty(criteria.StoreId))
            {
                query = query.Where(x => criteria.StoreId == x.StoreId);
            }

            return query;
        }
    }
}
