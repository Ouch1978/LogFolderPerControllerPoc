using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace LogFolderPerControllerPoc
{
    public class WebApiApplication : HttpApplication
    {
        private static string _configFolder;

        public static string ConfigFolder
        {
            get
            {
                if( string.IsNullOrEmpty( _configFolder ) )
                    _configFolder = HttpContext.Current.Server.MapPath( "\\Configuration\\" );

                return _configFolder;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure( WebApiConfig.Register );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );

            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            GlobalContext.Properties[ "ApplicationName" ] = "LogFolderPoc";

            GlobalContext.Properties[ "ControllerName" ] = "Application";

            XmlConfigurator.Configure( new FileInfo( Path.Combine( ConfigFolder , "Log4net.config" ) ) );

            var logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );
        }
    }
}