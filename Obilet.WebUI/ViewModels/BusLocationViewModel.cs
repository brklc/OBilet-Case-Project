using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Core.Models;
using System.Collections.Generic;

namespace Obilet.WebUI.ViewModels
{
    public class BusLocationViewModel
    {
        public SelectList DataSelectList { get; set; }

        public DataBusLocation DataBusLocation { get; set; }
    }
}
