using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Article article = new Article();
            lbTest.Text = article.SelectArticle().ToString();
            List<Article> listeArticles2 = new List<Article>();
            listeArticles2 = article.SelectArticle();

            foreach (var item in listeArticles2)
            {
                Panel vignetteDroite = new Panel();
                vignetteDroite.CssClass="vignetteDroite";
                panneauArticle.Controls.Add(vignetteDroite);
                Panel photoArticle = new Panel();
                photoArticle.CssClass = "photoArticle";
                Panel cadreNoir = new Panel();
                cadreNoir.CssClass = "cadreNoir";
                vignetteDroite.Controls.Add(cadreNoir);
                Panel vignetteNoire = new Panel();
                vignetteNoire.CssClass = "vignetteNoire";
                cadreNoir.Controls.Add(vignetteNoire);
                Panel contentArticle = new Panel();
                contentArticle.CssClass = "contentArticle";
                vignetteDroite.Controls.Add(photoArticle);
                
                HtmlGenericControl img = new HtmlGenericControl("img");
                Panel textArticle = new Panel();
                textArticle.CssClass = "textArticle";
                vignetteDroite.Controls.Add(textArticle);
                HtmlGenericControl texte = new HtmlGenericControl("p");
                texte.InnerText = item.Text;
                textArticle.Controls.Add(texte);
                photoArticle.Controls.Add(img);
                
                vignetteDroite.Controls.Add(contentArticle);
                
                
                

            }

            //public Panel BlocArticle()
            //{
            //    Panel panelBlocArticle = new Panel();
            //    panelBlocArticle.CssClass = "";
            //    Panel article1 = new Panel();
            //    article1.CssClass = "";

            //    Image imageArticle = new Image();
            //    imageArtic="";

            //}




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