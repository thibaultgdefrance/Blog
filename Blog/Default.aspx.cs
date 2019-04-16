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
            Rubrique rubrique = new Rubrique();
            Image imageArticle = new Image();
            lbTest.Text = article.SelectArticle().ToString();
            List<Article> listeArticles2 = new List<Article>();
            listeArticles2 = article.SelectArticle();

            foreach (var item in listeArticles2)
            {
                Panel contentDroit = new Panel();
                contentDroit.CssClass = "contentDroit";
                panneauArticle.Controls.Add(contentDroit);
                Panel vignetteDroite = new Panel();
                vignetteDroite.CssClass="vignetteDroite";
                contentDroit.Controls.Add(vignetteDroite);
                Panel photoArticle = new Panel();
                photoArticle.CssClass = "photoArticle";
                photoArticle.BackImageUrl= "/media/" + imageArticle.selectImage(item.IdArticle, 1);
                vignetteDroite.Controls.Add(photoArticle);
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                //img.CssClass = "img";
                //img.ImageUrl = "/media/"+imageArticle.selectImage(item.IdArticle, 1);
                
                //photoArticle.Controls.Add(img);
                Panel cadreNoir = new Panel();
                cadreNoir.CssClass = "cadreNoir";
                vignetteDroite.Controls.Add(cadreNoir);
                Panel vignetteNoire = new Panel();
                vignetteNoire.CssClass = "vignetteNoire";
                cadreNoir.Controls.Add(vignetteNoire);
                Label rubriqueArticle=new Label();
                rubriqueArticle.CssClass = "rubriqueArticle";
                rubriqueArticle.Text = "*"+rubrique.selectRubrique(item.IdRubrique)+"*";
                vignetteNoire.Controls.Add(rubriqueArticle);
                HtmlGenericControl titreArticle = new HtmlGenericControl("p");
                titreArticle.InnerText = item.Titre;
                vignetteNoire.Controls.Add(titreArticle);
                HtmlGenericControl descriptionArticle = new HtmlGenericControl("p");
                descriptionArticle.InnerText = item.Description;
                vignetteNoire.Controls.Add(descriptionArticle);
                HtmlGenericControl datePublication = new HtmlGenericControl("p");
                datePublication.InnerText = article.DatePublication.ToString();
                vignetteNoire.Controls.Add(datePublication);
                Panel contentArticle = new Panel();
                contentArticle.CssClass = "contentArticle";
                vignetteDroite.Controls.Add(contentArticle);
                Panel texteArticle = new Panel();
                texteArticle.CssClass = "textArticle";
                contentArticle.Controls.Add(texteArticle);
                HtmlGenericControl textArticle = new HtmlGenericControl("p");
                textArticle.InnerText = item.Text;
                texteArticle.Controls.Add(textArticle);
                Label buttonSuite = new Label();
                buttonSuite.CssClass = "suite";
                buttonSuite.Text = "Lire la suite";
                contentArticle.Controls.Add(buttonSuite);
                //Panel textArticle = new Panel();
                //textArticle.CssClass = "textArticle";
                //vignetteDroite.Controls.Add(textArticle);
                //HtmlGenericControl texte = new HtmlGenericControl("p");
                //texte.InnerText = item.Text;
                //textArticle.Controls.Add(texte);
                //photoArticle.Controls.Add(img);
                
                
                
                
                

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