﻿using System.Web.Mvc;

namespace WebPerformanceHelpers.Tests.Web.Controllers
{
    [OutputCache(CacheProfile = "Static")]
    [RoutePrefix("css")]
    public class CssController : Controller
    {
        [Route("inline-critical-css")]
        public ActionResult InlineCriticalCss()
        {
            return View();
        }
    }
}