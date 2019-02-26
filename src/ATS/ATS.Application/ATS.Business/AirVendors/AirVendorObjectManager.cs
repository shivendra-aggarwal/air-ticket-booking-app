using ATS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ATS.Common.ATSEnums;

namespace ATS.Business.AirVendors
{
    /// <summary>
    /// AirVendorObjectManager will take responsibility of each Air vendor 
    /// we have association with and to get its business object
    /// Note: Here we are using strategy pattern to efficiently utilize each air vendor
    /// features
    /// </summary>
    public class AirVendorObjectManager : IAirVendorObjectManager
    {
        private readonly Dictionary<string, object> airVendorObjects;
        private readonly IAirVendorFactory airVendorFactory;
        public AirVendorObjectManager(IAirVendorFactory airVendorFactory)
        {
            airVendorObjects = new Dictionary<string, object>();
            this.airVendorFactory = airVendorFactory;
            LoadObjectMapping(airVendorObjects);
        }

        /// <summary>
        /// To get an active instance of a vendor on demand
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<object> GetObjectByType(string name)
        {
            return airVendorObjects[name];
        }

        /// <summary>
        /// To load internal mapper of object using AirVendorFactory
        /// </summary>
        /// <param name="airVendorObjects"></param>
        private void LoadObjectMapping(IDictionary<string, object> airVendorObjects)
        {
            foreach(var vendor in Enum.GetNames(typeof(AirVendorEnum)))
            {
                if (!airVendorObjects.ContainsKey(vendor))
                {
                    airVendorObjects.Add(vendor, airVendorFactory.GetObject((AirVendorEnum)Enum.Parse(typeof(AirVendorEnum), vendor)));
                }
            }
        }


    }
}
