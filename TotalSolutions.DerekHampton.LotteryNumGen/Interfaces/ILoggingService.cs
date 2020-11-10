using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotalSolutions.DerekHampton.LotteryNumGen.Interfaces
{
    public interface ILoggingService
    {
        /// <summary>
        /// Log messages for audits and debugging.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogMessage(string context, string message);


        /// <summary>
        /// Log exceptions for audits and debugging.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        Task LogMessage(string context, Exception ex);
    }
}
