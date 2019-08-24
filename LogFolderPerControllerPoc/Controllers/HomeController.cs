using System.Reflection;
using System.Web.Mvc;
using log4net;
using LogFolderPerControllerPoc.Attributes;

namespace LogFolderPerControllerPoc.Controllers
{
    [MyAttributeA]
    [MyAttributeB]
    public class HomeController : Controller
    {
        private readonly ILog logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );

            return View();
        }
    }
}