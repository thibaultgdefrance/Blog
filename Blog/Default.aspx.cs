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
            Utilisateur utilisateur = new Utilisateur();
            Rubrique rubrique = new Rubrique();
            Image imageArticle = new Image();
            lbTest.Text = article.SelectArticle().ToString();
            List<Article> listeArticles2 = new List<Article>();
            listeArticles2 = article.SelectArticle();
            Commentaire commentaire = new Commentaire();
            
            foreach (var item in listeArticles2)
            {
                int IdArticle = item.IdArticle;
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
                

                HtmlGenericControl datePublication = new HtmlGenericControl("p");
                datePublication.InnerText = article.DatePublication.ToString();
                vignetteNoire.Controls.Add(datePublication);


                Panel contentArticle = new Panel();
                contentArticle.CssClass = "contentArticle";
                vignetteDroite.Controls.Add(contentArticle);


                Panel descriptionArticle = new Panel();
                descriptionArticle.CssClass = "descriptionArticle";
                contentArticle.Controls.Add(descriptionArticle);


                HtmlGenericControl descriptionText = new HtmlGenericControl("p");
                descriptionText.InnerText = item.Description;
                descriptionArticle.Controls.Add(descriptionText);


                HyperLink buttonSuite = new HyperLink();
                buttonSuite.CssClass = "suite";
                buttonSuite.Text = "Lire la suite";
                buttonSuite.NavigateUrl ="javascript:void(0)";
                buttonSuite.Attributes.Add("onclick", "afficherTexte(" + IdArticle + ")");
                contentArticle.Controls.Add(buttonSuite);


                Panel textArticle = new Panel();
                textArticle.CssClass = "textArticle";
                textArticle.ID = "texteComplet"+IdArticle;

                contentArticle.Controls.Add(textArticle);


                HtmlGenericControl texte = new HtmlGenericControl("p");
                texte.InnerText = item.Text;
                textArticle.Controls.Add(texte);

                Panel blocCommentaire = new Panel();
                textArticle.Controls.Add(blocCommentaire);



                
                Label ajouterUnCommentaire = new Label();
                ajouterUnCommentaire.CssClass = "Block";
                Label login = new Label();
                login.CssClass = "Block";
                login.Text = "Login";
                Label password = new Label();
                password.CssClass = "Block";
                password.Text = "Password";
                Label titreCommentaire = new Label();
                titreCommentaire.CssClass = "Block";
                titreCommentaire.Text = "Titre";


                ajouterUnCommentaire.Text = "Ajouter un commentaire";
                TextBox txtbLogin = new TextBox();
                txtbLogin.CssClass = "Block";
                TextBox txtbPassword = new TextBox();
                txtbPassword.CssClass = "Block";
                TextBox txtbTitreCommentaire = new TextBox();
                txtbPassword.CssClass = "Block";
                TextBox txtbCommentaire= new TextBox();
                HyperLink buttonCommentaire = new HyperLink();
                buttonCommentaire.NavigateUrl = "javascript:void(0)";
                buttonCommentaire.CssClass = "Block";
                buttonCommentaire.Attributes.Add("onclick", "enregistrerCommentaire()"); 
                buttonCommentaire.Text = "ajouter";
                txtbCommentaire.TextMode=TextBoxMode.MultiLine;
                txtbCommentaire.CssClass = "textCommentaire";
                blocCommentaire.Controls.Add(ajouterUnCommentaire);
                blocCommentaire.Controls.Add(login);
                blocCommentaire.Controls.Add(txtbLogin);
                blocCommentaire.Controls.Add(password);
                blocCommentaire.Controls.Add(txtbPassword);
                blocCommentaire.Controls.Add(titreCommentaire);
                blocCommentaire.Controls.Add(txtbTitreCommentaire);
                blocCommentaire.Controls.Add(txtbCommentaire);
                blocCommentaire.Controls.Add(buttonCommentaire);


                Panel listCommentaire = new Panel();
                listCommentaire.CssClass = "test";
                textArticle.Controls.Add(listCommentaire);

                List<Commentaire> listCommentaires2 = new List<Commentaire>();
                listCommentaires2 = commentaire.listeCommentaire(IdArticle);
                foreach (var item2 in listCommentaires2)
                {
                    HtmlGenericControl truc = new HtmlGenericControl("p");
                    truc.InnerText = "sqgv<sfd<";
                    listCommentaire.Controls.Add(truc),
                }



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