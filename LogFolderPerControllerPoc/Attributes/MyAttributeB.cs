using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using log4net;
using LogFolderPerControllerPoc.Extensions;

namespace LogFolderPerControllerPoc.Attributes
{
    public class MyAttributeB : ActionFilterAttribute, IExceptionFilter
    {
        private ILog logger;

        public async Task ExecuteExceptionFilterAsync( HttpActionExecutedContext actionExecutedContext ,
            CancellationToken cancellationToken )
        {
        }

        public override void OnActionExecuted( HttpActionExecutedContext context )
        {
            logger = context.ActionContext.GetLoggerWithControllerName( MethodBase.GetCurrentMethod().DeclaringType );

            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );
        }


        public override void OnActionExecuting( HttpActionContext actionContext )
        {
            logger = actionContext.GetLoggerWithControllerName( MethodBase.GetCurrentMethod().DeclaringType );

            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );
        }
    }
}