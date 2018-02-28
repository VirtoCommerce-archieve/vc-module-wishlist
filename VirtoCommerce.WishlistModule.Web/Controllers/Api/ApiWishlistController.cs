using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.Platform.Core.Web.Security;
using VirtoCommerce.WishlistModule.Core.Model;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Web.Models;

namespace VirtoCommerce.WishlistModule.Web.Controllers.Api
{
    [RoutePrefix("api/wishlists")]
    public class ApiWishlistController : ApiController
    {
        private readonly IWishlistLinkSearchService _wishlistLinkSearchService;
        private readonly IWishlistLinkService _wishlistLinkService;
        private readonly IWishlistSearchService _wishlistSearchService;
        private readonly IWishlistService _wishlistService;

        public ApiWishlistController(IWishlistLinkSearchService wishlistLinkSearchService, IWishlistLinkService wishlistLinkService, IWishlistSearchService wishlistSearchService, IWishlistService wishlistService)
        {
            _wishlistLinkSearchService = wishlistLinkSearchService;
            _wishlistLinkService = wishlistLinkService;
            _wishlistSearchService = wishlistSearchService;
            _wishlistService = wishlistService;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Wishlist))]
        public IHttpActionResult Get(string id)
        {
            var lists = _wishlistService.GetByIds(new[] {id});
            return Ok(lists.FirstOrDefault());
        }

        [HttpPost]
        [Route("search")]
        [ResponseType(typeof(WishlistSearchResult))]
        public IHttpActionResult Search(WishlistSearchCriteria criteria)
        {
            var searchResult = _wishlistSearchService.Search(criteria);
            var result = new WishlistSearchResult
            {
                Results = searchResult.Results,
                TotalCount = searchResult.TotalCount
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Wishlist))]
        public IHttpActionResult CreateWishlist(Wishlist wishlist)
        {
            _wishlistService.SaveOrUpdate(new[] { wishlist });
            return Ok(wishlist);
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateWishlist(Wishlist wishlist)
        {
            _wishlistService.SaveOrUpdate(new[] { wishlist });
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(void))]
        public IHttpActionResult RemoveWishlistsByIds([FromUri] string[] ids)
        {
            _wishlistService.RemoveByIds(ids);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
