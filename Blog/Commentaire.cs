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
        int IdCommentaire = 0;
        string TitreCommentaire = "";
        string TexteCommentaire = "";
        string DatePublication = "";
        string DateModification = "";
        int Popularite = 0;
        //int IdArticle = 0;
        int IdStatut = 0;
        int IdAuteur = 0;


        
        string cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int ajouterCommentaire(string Titre,string Texte,string datePublication,string dateModification,int Popularite,int IdArticle,int IdStatut,int IdAuteur,string email,string password)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            try
            {
                
                sqlConnection.Open();
                SqlCommand cmd2 = new SqlCommand("select IdUtilisateur from dbo.Utilisateur where email=@email AND MotDePasse=@MotDePasse",sqlConnection);
                cmd2.Parameters.AddWithValue("@email", email);
                cmd2.Parameters.AddWithValue("@MotDePasse",password);
                int result = Int32.Parse(cmd2.ExecuteScalar().ToString());
                sqlConnection.Close();
                
                if (result>0)
                {
                    
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into dbo.Commentaire(TitreCommentaire,TexteCommentaire,DatePublication,DateModification,Popularite,IdArticle,IdStatut,IdAuteur)values(@TitreCommentaire,@TexteCommentaire,@DatePublication,@DateModification,@Popularite,@IdArticle,@IdStatut,@IdAuteur)", sqlConnection);

                    cmd.Parameters.AddWithValue("@TitreCommentaire", Titre);
                    cmd.Parameters.AddWithValue("@TexteCommentaire", Texte);
                    cmd.Parameters.AddWithValue("@DatePublication", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@DateModification", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Popularite", Popularite);
                    cmd.Parameters.AddWithValue("@IdArticle", IdArticle);
                    cmd.Parameters.AddWithValue("@IdStatut", IdStatut);
                    cmd.Parameters.AddWithValue("@IdAuteur", result);
                    cmd.ExecuteScalar();

                    sqlConnection.Close();
                    return 1;
                }
                
                
                
            }
            catch (Exception)
            {
                sqlConnection.Close();

            }

            return 0;
        }

        public /*List<Commentaire>*/ SqlDataReader listeCommentaire(int IdArticle)
        {
            //List<Commentaire> listeCommentaires = new List<Commentaire>();
            
               
                SqlConnection sqlConnection3 = new SqlConnection(cnx);
                sqlConnection3.Open();
                SqlCommand cmd3 = new SqlCommand("select * from dbo.Commentaire where IdArticle=@IdArticle order by DatePublication ASC ", sqlConnection3);
                cmd3.Parameters.AddWithValue("@IdArticle",IdArticle);
                SqlDataReader reader = cmd3.ExecuteReader();

            //while (reader.Read())
            //{
            //    Commentaire commentaire = new Commentaire();
            //    commentaire.IdCommentaire = Int32.Parse(reader[0].ToString());
            //    commentaire.TitreCommentaire = reader[1].ToString();
            //    commentaire.TexteCommentaire = reader[2].ToString();
            //    commentaire.DatePublication = reader[3].ToString();
            //    commentaire.DateModification = reader[4].ToString();
            //    commentaire.Popularite = Int32.Parse(reader[5].ToString());
            //    commentaire.IdArticle = Int32.Parse(reader[6].ToString());
            //    commentaire.IdStatut = Int32.Parse(reader[7].ToString());
            //    commentaire.IdAuteur = Int32.Parse(reader[8].ToString());

            //}
                    //listeCommentaires.Add(commentaire);
            return reader;
             
            //return listeCommentaires;

        }


    }

    
}