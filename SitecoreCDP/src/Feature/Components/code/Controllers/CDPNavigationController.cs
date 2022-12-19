using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitecoreCDP.Feature.Components.Models;

namespace SitecoreCDP.Feature.Components.Controllers
{
    public class CDPNavigationController : Controller
    {
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var contextDB = Sitecore.Configuration.Factory.GetDatabase(Sitecore.Context.Database.Name);
            var rootItem = contextDB.GetItem(Sitecore.Context.Site.StartPath);
            var listItems = rootItem.GetChildren();

            MainNavigationModel mainNavigation = new MainNavigationModel
            {
                HomeNavigationUrl = LinkManager.GetItemUrl(rootItem),
                HomeTitle = rootItem.DisplayName,
                MainLinks = listItems.Select(x => new MainLinkItems
                {
                    NavigationTitle = x.DisplayName,
                    NavigationURL = LinkManager.GetItemUrl(x),
                    SubNavigationItems = GetSubNavigationItems(x)
                }).ToList()
            };
            return View(mainNavigation);
        }

        public List<SubLink> GetSubNavigationItems(Sitecore.Data.Items.Item mainNavigationItem)
        {
            if (mainNavigationItem.HasChildren)
            {
                var subNavigationItems = mainNavigationItem.Children;
                List<SubLink> subLinks = subNavigationItems.Select(x => new SubLink
                {
                    SubNavigationTitle = x.DisplayName,
                    SubNavigationURL = LinkManager.GetItemUrl(x),
                }).ToList();
                return subLinks;
            }
            else
            {
                return new List<SubLink>();
            }
        }
    }
}