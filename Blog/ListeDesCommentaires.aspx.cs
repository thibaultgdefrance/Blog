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

            string Titre = "";
            string Text = "";
            string datePublication = DateTime.Now.ToShortDateString();
            string dateModification = DateTime.Now.ToShortDateString();
            int Popularite = 0;
            int IdArticle = 4;
            int IdStatut = 1;
            int IdAuteur =3;

            //int IdArticle = Request.QueryString[1];
            Commentaire commentaire = new Commentaire();
            //commentaire.listeCommentaire(IdArticle);
            commentaire.ajouterCommentaire(Titre,Text,datePublication,dateModification,Popularite,IdArticle,IdStatut,IdAuteur);
        }
         

        
    }
}