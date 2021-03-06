﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                txtbLogin.CssClass = "Block Login"+IdArticle+"";
                TextBox txtbPassword = new TextBox();
                txtbPassword.CssClass = "Block Password"+IdArticle+"";
                TextBox txtbTitreCommentaire = new TextBox();
                txtbTitreCommentaire.CssClass = "Block Titre"+IdArticle+"";
                TextBox txtbCommentaire= new TextBox();
                txtbCommentaire.CssClass = "Texte" + IdArticle;
                HyperLink buttonCommentaire = new HyperLink();
                buttonCommentaire.NavigateUrl = "javascript:void(0)";
                buttonCommentaire.CssClass = "Block control-form"+IdArticle+"";
                
                buttonCommentaire.Text = "ajouter";
                txtbCommentaire.TextMode=TextBoxMode.MultiLine;
                txtbCommentaire.CssClass = "textCommentaire texteCommentaire"+IdArticle+"";
                blocCommentaire.Controls.Add(ajouterUnCommentaire);
                blocCommentaire.Controls.Add(login);
                blocCommentaire.Controls.Add(txtbLogin);
                blocCommentaire.Controls.Add(password);
                blocCommentaire.Controls.Add(txtbPassword);
                blocCommentaire.Controls.Add(titreCommentaire);
                blocCommentaire.Controls.Add(txtbTitreCommentaire);
                blocCommentaire.Controls.Add(txtbCommentaire);
                blocCommentaire.Controls.Add(buttonCommentaire);
                buttonCommentaire.Attributes.Add("onclick","enregistrerCommentaire('" + IdArticle +"','"+txtbTitreCommentaire.Text+"','"+txtbCommentaire.Text+"','"+DateTime.Now+"')");


                Panel listCommentaire = new Panel();
                listCommentaire.CssClass = "test blocCommentaire"+IdArticle;
                textArticle.Controls.Add(listCommentaire);
                SqlDataReader reader = commentaire.listeCommentaire(IdArticle);
                Panel autoCom = new Panel();
                autoCom.CssClass = "com autoCom" + IdArticle;
                autoCom.ID = "autoCom" + IdArticle;
                listCommentaire.Controls.Add(autoCom);
                while (reader.Read())
                {

                    int IdCommentaire = Int32.Parse(reader[0].ToString());
                    Panel com = new Panel();
                    com.CssClass = "com cm"+IdCommentaire;
                    com.ID = "cm"+IdCommentaire;
                    Label textDeCommentaire = new Label();
                    Label titreDeCommentaire = new Label();
                    Label dateCommentaire = new Label();
                    HyperLink masquerCommentaire = new HyperLink();
                    masquerCommentaire.NavigateUrl = "javascript:void(0)";
                    masquerCommentaire.CssClass = "masquerCommentaire ";
                    masquerCommentaire.ID = "cm" + IdCommentaire;
                    masquerCommentaire.Text = "masquer commentaire";
                    masquerCommentaire.Attributes.Add("onclick", "masquerCommentaire('" + IdCommentaire + "')");
                    dateCommentaire.CssClass = "dateCommentaire";
                    titreDeCommentaire.CssClass = "titreDeCommentaire";
                    textDeCommentaire.CssClass = "textDeCommentaire";
                    titreDeCommentaire.Text = reader[1].ToString()+" :";
                    textDeCommentaire.Text = reader[2].ToString();
                    dateCommentaire.Text = "ajouter le " + reader[3].ToString();
                    com.Controls.Add(titreDeCommentaire);
                    com.Controls.Add(textDeCommentaire);
                    com.Controls.Add(dateCommentaire);
                    com.Controls.Add(masquerCommentaire);
                    
                    listCommentaire.Controls.Add(com);

                }
                



            }

            




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