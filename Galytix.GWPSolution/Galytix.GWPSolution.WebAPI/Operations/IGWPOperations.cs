using System.Collections.Generic;

namespace Galytix.GWPSolution.WebAPI.Operations
{
    /// <summary>
    /// Operation definations related to GWP.
    /// </summary>
    public interface IGWPOperations
    {
        /// <summary>
        /// Defination of method return average for country and line of business.
        /// </summary>
        /// <param name="gwpAverageRequestModel">Request payload</param>
        /// <returns>Return lob and average.</returns>
        public Dictionary<string, decimal> GetGwpAverage(Model.GwpAverageRequestModel gwpAverageRequestModel);
    }
}
