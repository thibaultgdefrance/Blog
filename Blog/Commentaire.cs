using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Commentaire
    {
        public Commentaire()
        {

        }

        string cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void ajouterCommentaire(string Titre,string Texte,string datePublication,string dateModification,int Popularite,int IdArticle,int IdStatut,int IdAuteur)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Insert Into dbo.Commentaire(TitreCommentaire,TexteCommentaire,DatePublication,DateModification,Popularite,IdArticle,IdStatut,IdAuteur)values(@TitreCommentaire,@TexteCommentaire,@DatePublication,@DateModification,@Popularite,@IdArticle,@IdStatut,@IdAuteur)", sqlConnection);
                cmd.Parameters.AddWithValue("@TitreCommentaire",Titre);
                cmd.Parameters.AddWithValue("@TexteCommentaire",Texte);
                cmd.Parameters.AddWithValue("@DatePublication",DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@DateModification", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@Popularite",Popularite);
                cmd.Parameters.AddWithValue("@IdArticle",IdArticle);
                cmd.Parameters.AddWithValue("@IdStatut",IdStatut);
                cmd.Parameters.AddWithValue("@IdAuteur",IdAuteur);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }



    }

    
}