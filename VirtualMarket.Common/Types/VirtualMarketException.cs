using System;

namespace VirtualMarket.Common.Types
{
    public class VirtualMarketException : Exception
    {
        public string Code { get; }
        public VirtualMarketException() { }
        public VirtualMarketException(string code)
        {
            Code = code;
        }
        public VirtualMarketException(string message, params object[] args)
            : this(string.Empty, message, args)
        {

        }
        public VirtualMarketException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {

        }
        public VirtualMarketException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public VirtualMarketException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
