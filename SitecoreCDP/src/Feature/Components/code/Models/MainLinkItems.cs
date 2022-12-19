using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCDP.Feature.Components.Models
{
    public class MainLinkItems
    {
        public string NavigationTitle { get; set; }
        public string NavigationURL { get; set; }
        public bool IsCurrentPage { get; set; }
        public List<SubLink> SubNavigationItems { get; set; }
    }
}