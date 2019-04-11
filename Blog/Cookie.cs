using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Cookie : System.Web.UI.Page
    {
        public void enregistrerCookies()
        {

        }
        public void supprimerCookies()
        {
            HttpCookie emailBlog = new HttpCookie("userEmail");
            Request.Cookies.Add(emailBlog);
            emailBlog.Expires = DateTime.Now.AddDays(-1);

            HttpCookie userNiveau = new HttpCookie("userNiveau");
            Request.Cookies.Add(userNiveau);
            userNiveau.Expires = DateTime.Now.AddDays(-1);


        }
    }
}