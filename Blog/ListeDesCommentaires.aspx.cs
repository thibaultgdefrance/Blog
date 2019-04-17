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
            //int IdArticle = Request.QueryString[1];
            Commentaire commentaire = new Commentaire();
            //commentaire.listeCommentaire(IdArticle);
            
        }
        
        
    }
}