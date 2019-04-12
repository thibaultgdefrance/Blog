using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class admin : System.Web.UI.Page
    {
        
        string repImages = ConfigurationManager.AppSettings["RepImages"];
        string[] listeImage = new string[10];
        List<string> listImages= new List<string>();
        int cpt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Rubrique rubrique = new Rubrique();

            String urlActuelle = HttpContext.Current.Request.Path;
            if (Request.Cookies.Get("userNiveau")== null && Session["email"]==null)
            {
                Response.Redirect("/connexion.aspx");
            }

            else if (Session["niveau"] !=null && Session["niveau"].ToString()=="1")
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

        protected void btnAjoutRubrique_Click(object sender, EventArgs e)
        {
            if (txtbRubrique.Text!="")
            {
                Rubrique rubrique = new Rubrique();
                int result = rubrique.creerRubrique(txtbRubrique.Text);
                GridView2.DataBind();
            }
            

        }

        protected void btnAjoutArticle_Click(object sender, EventArgs e)
        {
       
            Article article = new Article();
            int result = article.creerArticle(txtbTitre.Text, txtbDescription.Text, textArticle.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), 5, 2, Int32.Parse(ddlStatut.SelectedValue), Int32.Parse(ddlRubrique.SelectedValue));

            try
            {
                Image image = new Image();
                image.ajouterImage(lbListeImages.Text, DateTime.Now, "", result);
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuAjouterImage.HasFile)
            {
               
               string fichier = fuAjouterImage.FileName;
                try
                {
                    fuAjouterImage.SaveAs(repImages + fichier);
                    listImages.Add(repImages + fichier);
                    lbListeImages.Text += fichier+"br/";
                }
                catch (Exception ex)
                {
                    lbListeImages.Text += ex.Message;
                    
                }
               

            }
            
        }
    }
}