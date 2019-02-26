using System;
using System.Collections.Generic;
using System.Text;
using static ATS.Common.ATSEnums;

namespace ATS.Business.Interfaces
{
    public interface IAirVendorFactory
    {
        object GetObject(AirVendorEnum airVendor);
    }
}
