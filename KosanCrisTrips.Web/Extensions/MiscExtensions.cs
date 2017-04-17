using KosanCrisTrips.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KosanCrisTrips.Web.Extensions
{
    public static class MiscExtensions
    {
        public static List<SelectListItem> ToSelectListItems(this List<LookUpViewModel> lookUpViewModel)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem defaultSelectListItem = new SelectListItem();

            defaultSelectListItem.Text = "Select";
            defaultSelectListItem.Value = "0";

            selectListItems.Add(defaultSelectListItem);
            foreach (var item in lookUpViewModel)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.Id.ToString();

                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}