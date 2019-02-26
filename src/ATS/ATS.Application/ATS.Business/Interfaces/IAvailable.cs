using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces
{
    public interface IAvailable
    {
        /// <summary>
        /// This method will help us to identify that registered vendors are available or not
        /// </summary>
        /// <param name="accessUrl"></param>
        /// <returns></returns>
        Task<bool> CheckAvailability(string accessUrl);
    }
}
