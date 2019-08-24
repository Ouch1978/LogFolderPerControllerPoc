using System;
using System.IO;
using System.Reflection;
using System.Web.Http.Controllers;
using log4net;
using log4net.Config;

namespace LogFolderPerControllerPoc.Extensions
{
    static class HttpActionContextExtensions
    {
        public static ILog GetLoggerWithControllerName( this HttpActionContext actionContext , Type declaringType )
        {
            ThreadContext.Properties[ "ControllerName" ] =
                actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            XmlConfigurator.Configure( new FileInfo( Path.Combine( WebApiApplication.ConfigFolder , "Log4net.config" ) ) );

            return LogManager.GetLogger( declaringType );
        }
    }
}