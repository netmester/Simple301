using Umbraco.Web.Routing;
using System.Linq;
using Simple301.Core.Models;

namespace Simple301.Core
{
    /// <summary>
    /// Content finder to be injected at the start of the Umbraco pipeline that first
    /// looks for any redirects that path the path + query
    /// </summary>
    public class RedirectContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest request)
        {
            //Get the requested URL path + query
            var path = request.Uri.PathAndQuery.ToLower();
            var fullpath = request.Uri.OriginalString.ToLower();

            //Check the table
            var redirectLookupTable = RedirectRepository.GetLookupTable();

            Redirect matchedRedirect;
            if (redirectLookupTable.TryGetValue(path, out matchedRedirect))
            {
                // set the 301 redirect on the request and return
                request.SetRedirectPermanent(matchedRedirect.NewUrl);
                return true;
            }

            if (redirectLookupTable.TryGetValue(fullpath, out matchedRedirect))
            {
                // set the 301 redirect on the request and return
                request.SetRedirectPermanent(matchedRedirect.NewUrl);
                return true;
            }


            //did not found one
            return false;
        }
    }
}
