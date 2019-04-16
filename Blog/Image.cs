using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Image
    {

        string cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int IdImage = 0;
        public string CheminImage = "";
        public DateTime DatePublication = DateTime.Now;
        public string TitreImage = "";
        public int IdArticle = 0;
        public Image()
        {

        }

        public void ajouterImage(String UrlImage, DateTime DatePublication, String DescriptionImage, int IdArticle)
        {
            
            string[] listImages = new string[800];
            listImages = UrlImage.Split('|');
            foreach (var item in listImages)
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                String cmdAjout = "Insert into dbo.Image (UrlImage,DatePublication,DescriptionImage,IdArticle)values(@UrlImage,@DatePublication,@DescriptionImage,@IdArticle)";
                SqlCommand ajout = new SqlCommand(cmdAjout, sqlConnection);
                ajout.Parameters.AddWithValue("@UrlImage", item);
                ajout.Parameters.AddWithValue("@DatePublication", DateTime.Now);
                ajout.Parameters.AddWithValue("@DescriptionImage", DescriptionImage);
                ajout.Parameters.AddWithValue("@IdArticle", IdArticle);
                ajout.ExecuteNonQuery();
                sqlConnection.Close();
            }


            
        }

        public string selectImage(int IdArticle,int numPhoto)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand cmd2 = new SqlCommand("select count(*) from dbo.Image where IdArticle = @IdArticle",sqlConnection);
                cmd2.Parameters.AddWithValue("@IdArticle",IdArticle);
                int result2 = Int32.Parse(cmd2.ExecuteScalar().ToString());
                if (result2>0)
                {
                    SqlCommand cmd = new SqlCommand("select top(@numPhoto)UrlImage from dbo.Image where IdArticle = @IdArticle", sqlConnection);
                    cmd.Parameters.AddWithValue("@IdArticle", IdArticle);
                    cmd.Parameters.AddWithValue("@numPhoto", numPhoto);
                    string result = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();
                    return result;
                }
                else
                {
                    sqlConnection.Close();
                    return "office-1516329_960_720.jpg";
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}