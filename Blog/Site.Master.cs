using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(Object sender ,EventArgs e)
        {
            //var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            //Guid requestCookieQuidValue;
            //if (requestCookie != null && Guid.TryParse(requestCookie.Value,out requestCookieGuidValue)
            //{

            //}
            //else
            //{

            //}
            var reqCookie = Request.Cookies["userEmail"];
            string urlActuelle = HttpContext.Current.Request.Path;
            HttpCookie cookie = Request.Cookies["niveauUser"];
            if (cookie != null && cookie.Value != "2" && cookie.Expires>= DateTime.Now || (Session["email"]!=null && Session["niveau"].ToString()=="2")&&urlActuelle.Contains("Admin")) 
            {
               
            }
            else if (urlActuelle.Contains("Admin"))
            {
                Response.Redirect("/connexion.aspx");
            }

            if (Session["niveau"] !=null)
            {

            }

            if (reqCookie==null && urlActuelle.Contains("Administration"))
            {
                Response.Redirect("/Default.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}