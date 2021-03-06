﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace LogFolderPerControllerPoc.Controllers
{
    using Attributes;
    using log4net;

    [MyAttributeA]
    [MyAttributeB]
    public class ValuesController : ApiController
    {
        ILog logger = LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        // GET api/values
        public IEnumerable<string> Get()
        {
            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );

            return new string[] { "value1" , "value2" };
        }

        // GET api/values/5
        public string Get( int id )
        {

            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );

            return "value";
        }

        // POST api/values
        public void Post( [FromBody]string value )
        {
            var methodName = MethodBase.GetCurrentMethod().Name;

            logger.Debug( $"[{methodName}] - Debug" );
            logger.Info( $"[{methodName}] - Info" );
            logger.Warn( $"[{methodName}] - Warn" );
            logger.Error( $"[{methodName}] - Error" );
            logger.Fatal( $"[{methodName}] - Fatal" );

        }

        // PUT api/values/5
        public void Put( int id , [FromBody]string value )
        {
        }

        // DELETE api/values/5
        public void Delete( int id )
        {
        }
    }
}
