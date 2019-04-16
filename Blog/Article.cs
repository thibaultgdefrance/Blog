using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Article
    {
        public String Titre="";
        public String Description="";
        public String Text="";
        public String DatePublication="";
        public String DateModif="";
        public int Popularite=0;
        public int IdAuteur;
        public int IdStatut;
        public int IdRubrique;
        public Article(){
        
        }
        String cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int creerArticle(String TitreArticle, String DescriptionArticle, String TexteArticle,String DatePublication,String DateModif,int Popularite,int IdAuteur, int IdStatut1, int IdRubrique)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Insert into dbo.Article(TitreArticle,DescriptionArticle,TexteArticle,DatePublication,DateModif,Popularite,IdAuteur,IdStatut,IdRubrique)values(@TitreArticle,@DescriptionArticle,@TexteArticle,@DatePublication,@DateModif,@Popularite,@IdAuteur,@IdStatut,@IdRubrique);Select top(1)IdArticle from dbo.Article order by IdArticle desc";

            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@TitreArticle",TitreArticle);
            sqlCommand.Parameters.AddWithValue("@DescriptionArticle", DescriptionArticle);
            sqlCommand.Parameters.AddWithValue("@TexteArticle", TexteArticle);
            sqlCommand.Parameters.AddWithValue("@DatePublication", DatePublication);
            sqlCommand.Parameters.AddWithValue("@DateModif", DateModif);
            sqlCommand.Parameters.AddWithValue("@Popularite", Popularite);
            sqlCommand.Parameters.AddWithValue("@IdAuteur", IdAuteur);
            sqlCommand.Parameters.AddWithValue("@IdStatut", IdStatut1);
            sqlCommand.Parameters.AddWithValue("@IdRubrique", IdRubrique);

            int idArticle = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
            sqlConnection.Close();
            return idArticle;
        }
        public List<Article> SelectArticle()
        {
            List<Article> listArticles = new List<Article>();
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Select * From dbo.Article ";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            //String result=sqlCommand.ExecuteScalar().ToString();
            
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Article article = new Article();
                article.Titre =reader[1].ToString();
                article.Description =reader[2].ToString();
                article.Text=reader[3].ToString();
                article.DatePublication = reader[4].ToString();
                article.DateModif = reader[5].ToString();
                article.Popularite = Int32.Parse( reader[6].ToString());
                article.IdAuteur = Int32.Parse(reader[7].ToString());
                article.IdStatut = Int32.Parse(reader[8].ToString());
                article.IdRubrique = Int32.Parse(reader[9].ToString());
                listArticles.Add(article);
            }
            
            
            sqlConnection.Close();
            return listArticles;
        }
        public int ModifierArticle(String TitreArticle, String DescriptionArticle, String TexteArticle, String DatePublication, String DateModif, int Popularite, int IdAuteur, int IdStatut, int IdRubrique)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Update dbo.Article set TitreArticle=@TitreArticle,DescriptionArticle=@DescriptionArticle,TexteArticle=@TexteArticle,DatePublication=@DatePublication,DateModif=@DateModif,Popularite=@Popularite,IdAuteur=@IdAuteur,IdStatut=@IdStatut,IdRubrique=@IdRubrique";

            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@TitreArticle", TitreArticle);
            sqlCommand.Parameters.AddWithValue("@DescriptionArticle", DescriptionArticle);
            sqlCommand.Parameters.AddWithValue("@TexteArticle", TexteArticle);
            sqlCommand.Parameters.AddWithValue("@DatePublication", DatePublication);
            sqlCommand.Parameters.AddWithValue("@DateModif", DateModif);
            sqlCommand.Parameters.AddWithValue("@Popularite", Popularite);
            sqlCommand.Parameters.AddWithValue("@IdAuteur", IdAuteur);
            sqlCommand.Parameters.AddWithValue("@IdStatut", IdStatut);
            sqlCommand.Parameters.AddWithValue("@IdRubrique", IdRubrique);

            int Result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return Result;
        }

        public int supprimerArticle(int IdArticle)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                String req = "Delete from dbo.Article where IdArticle = @IdArticle";
                SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IdArticle", IdArticle);
                int Result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public DataTable listArticleAdmin()
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "select * from dbo.Article";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);
            sqlConnection.Close();
            return dt;
        }

        public SqlDataReader listArticlePublic()
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "select * from dbo.Article";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
    }
}