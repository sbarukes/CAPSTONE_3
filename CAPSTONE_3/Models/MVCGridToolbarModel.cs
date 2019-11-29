using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGrid.Web.Models
{
    // Part of MVCGrid.NET, see referance documentation: http://mvcgrid.net/demo/toolbar
    public class MVCGridToolbarModel
    {
        public MVCGridToolbarModel()
        {

        }

        public MVCGridToolbarModel(string gridName)
        {
            MVCGridName = gridName;
        }

        public string MVCGridName { get; set; }
        public bool PageSize { get; set; }
        public bool ColumnVisibility { get; set; }
        public bool Export { get; set; }
        public bool GlobalSearch { get; set; }
    }
}