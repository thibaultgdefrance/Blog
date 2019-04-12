﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("emailBlog")!=null)
            {
                HttpCookie httpCookie = Request.Cookies.Get("emailBlog");
                lbCookie.Text = httpCookie.Value+httpCookie.Expires.ToLongDateString();
            }
            String urlActuelle = HttpContext.Current.Request.Path;
            //if (urlActuelle.Contains("cookie=true"))
            //{

            //}
            //else
            //{
            //    HttpCookie emailBlog = Request.Cookies.Get("emailBlog");
            //    emailBlog.Expires=DateTime.Now.AddDays(-1);
            //    HttpCookie userNiveau = Request.Cookies.Get("userNiveau");
            //    userNiveau.Expires = DateTime.Now.AddDays(-1);
            //}
            
           
            
            Panel Article = new Panel();
            Article.CssClass = "vignetteDroite";
            
        }
        
        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Session.Abandon();



        }
    }
}