using Simple301.Core.Models;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web.Routing;

namespace Simple301.Core
{
    public class MyApplication : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentFinderResolver.Current.InsertType<RedirectContentFinder>(0);
        }

        /// <summary>
        /// On Application Started we need to ensure that the Redirects table exists. If not, create it
        /// </summary>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var db = applicationContext.DatabaseContext.Database;
            if (!db.TableExist("Redirects"))
            {
                db.CreateTable<Redirect>(false);
            }

        }
    }
}
