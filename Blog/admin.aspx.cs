using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String urlActuelle = HttpContext.Current.Request.Path;
            if (Request.Cookies.Get("userNiveau")== null && Session["email"]==null)
            {
                Response.Redirect("/connexion.aspx");
            }

            else if (Session["niveau"] !=null&& Session["niveau"].ToString()=="1")
            {

            }
            else if (Request.Cookies.Get("userNiveau")!=null && Request.Cookies.Get("userNiveau").ToString()=="1")
            {

            }
            else
            {
                Response.Redirect("/connexion.aspx");
            }
            //else if (urlActuelle.Contains("cookie=true"))
            //{

            //}
            //else
            //{
            //    HttpCookie emailBlog = Request.Cookies.Get("emailBlog");
            //    emailBlog.Expires = DateTime.Now.AddDays(-1);
            //    HttpCookie userNiveau = Request.Cookies.Get("userNiveau");
            //    userNiveau.Expires= DateTime.Now.AddDays(-1);
            //}
            
        }

        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/connexion.aspx");
        }
    }
}