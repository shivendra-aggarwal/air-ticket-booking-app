using ATS.Business.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ATS.Business.AirVendors
{
    public abstract class BaseAirVendor : IAvailable
    {
        /// <summary>
        /// To check whether a given url server is up and running or not
        /// </summary>
        /// <param name="accessUrl"></param>
        /// <returns></returns>
        public async Task<bool> CheckAvailability(string accessUrl)
        {
            bool status = default(bool);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(accessUrl);

                    status = response.IsSuccessStatusCode;
                }
            }
            catch (PingException ex)
            {
                //TODO:: logging mechanism to be introduced.
                status = false;
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }
    }
}
