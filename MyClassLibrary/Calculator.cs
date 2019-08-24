using System.Reflection;
using log4net;

namespace MyClassLibrary
{
    public class Calculator
    {
        private static readonly ILog logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

        public static int Add( int numberA , int numberB )
        {
            logger.Debug( $"numberA = {numberA}, numberB = {numberB}" );

            return numberA + numberB;
        }
    }
}