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
            SqlConnection sqlConnection = new SqlConnection(cnx);
            String cmdAjout = "Insert into dbo.Image (UrlImage,DatePublication,DescriptionImage,IdArticle)values(@UrlImage,@DatePublication,@DescriptionImage,@IdArticle)";
            SqlCommand ajout = new SqlCommand(cmdAjout, sqlConnection);
            ajout.Parameters.AddWithValue("@UrlImage",UrlImage);
            ajout.Parameters.AddWithValue("@DatePublication", DateTime.Now);
            ajout.Parameters.AddWithValue("@DescriptionImage", "");
            ajout.Parameters.AddWithValue("@IdArticle", IdArticle);
        }


    }
}