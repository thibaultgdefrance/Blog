using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class ListeDesCommentaires : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Titre = Request.QueryString["titre"];
            string Text = Request.QueryString["texte"];
            string datePublication = DateTime.Now.ToShortDateString();
            string dateModification = DateTime.Now.ToShortDateString();
            int Popularite = 0;
            int IdArticle2 = Int32.Parse(Request.QueryString["IdArticle2"]);
            int IdStatut = 1;
            int IdAuteur =0;
            string email = Request.QueryString["login"];
            string password = Request.QueryString["password"];
            Commentaire commentaire = new Commentaire();
            
            commentaire.ajouterCommentaire(Titre,Text,datePublication,dateModification,Popularite,IdArticle2,IdStatut,IdAuteur,email,password);
        }
         

        
    }
}