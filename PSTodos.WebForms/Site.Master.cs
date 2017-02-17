using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSTodos.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        public Toastr Toastr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Toastr = new Toastr();
        }

        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().Contains(page.ToLower()) ? "active" : "";
        }
    }
}