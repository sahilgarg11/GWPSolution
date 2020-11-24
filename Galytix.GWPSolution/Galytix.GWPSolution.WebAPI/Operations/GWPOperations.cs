using Galytix.GWPSolution.WebAPI.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galytix.GWPSolution.WebAPI.Operations
{

    /// <summary>
    /// Implemantation of definations related to GWP.
    /// </summary>
    public class GWPOperations : IGWPOperations
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger _logger;
        public GWPOperations(ILogger<GWPOperations> logger)
        {
            this._logger = logger;
        }
        /// <summary>
        /// Implemantation of method return average for country and line of business.
        /// </summary>
        /// <param name="gwpAverageRequestModel">Request payload</param>
        /// <returns>Return lob and average.</returns>
        public Dictionary<string, decimal> GetGwpAverage(GwpAverageRequestModel gwpAverageRequestModel)
        {
            this._logger.LogInformation("Request payload country '{0}' and LOB '{1}'", gwpAverageRequestModel.Country, gwpAverageRequestModel.LineOfBusiness);
            var finalAverage = new Dictionary<string, decimal>();
            try
            {
                if (ApplicationSharedInstance.GWPCountryData != null && ApplicationSharedInstance.GWPCountryData.Any())
                {
                    var filteredCountryData = ApplicationSharedInstance.GWPCountryData.Where(x => x.Country == gwpAverageRequestModel.Country);
                    if (filteredCountryData != null && filteredCountryData.Any())
                    {
                        gwpAverageRequestModel.LineOfBusiness.ForEach(x =>
                        {
                            var lineOfBusinessFiltered = filteredCountryData.Where(y => y.LineOfBusiness == x).FirstOrDefault();
                            if (lineOfBusinessFiltered != null)
                            {
                                var result = (ConvertToDecimal(lineOfBusinessFiltered.Y2008) + ConvertToDecimal(lineOfBusinessFiltered.Y2009) + ConvertToDecimal(lineOfBusinessFiltered.Y2010) +
                                  ConvertToDecimal(lineOfBusinessFiltered.Y2011) + ConvertToDecimal(lineOfBusinessFiltered.Y2012) +
                                  ConvertToDecimal(lineOfBusinessFiltered.Y2013) + ConvertToDecimal(lineOfBusinessFiltered.Y2014) + ConvertToDecimal(lineOfBusinessFiltered.Y2015)) / 8;
                                finalAverage.Add(x, result);
                            }
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }

            return finalAverage;
        }

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="value">string input.</param>
        /// <returns>returns decimal.</returns>
        private decimal ConvertToDecimal(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Convert.ToDecimal(value);
            }
            return default(decimal);
        }

    }
}
