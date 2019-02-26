using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATS.UI.Models;
using ATS.UI.Attributes;

namespace ATS.UI.Controllers
{
    [ServiceFilter(typeof(HandleExceptionAttribute))]
    public class BaseController : Controller
    {
        
    }
}
