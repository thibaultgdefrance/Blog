using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Cookie : System.Web.UI.Page
    {
        public void enregistrerCookies(String nom , String value)
        {
           
            
            HttpCookie httpCookie = new HttpCookie(nom,value);
            HttpContext.Current.Response.Cookies.Add(httpCookie);

        }
        public void supprimerCookies(String nom)
        {

            HttpCookie httpCookie = new HttpCookie(nom, "");
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            httpCookie.Expires = DateTime.Now;
            

        }
    }
}