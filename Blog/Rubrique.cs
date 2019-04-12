using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Rubrique
    {
        int IdRubrique = 0;
        String cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog = Blog; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        String IntituleRubrique = "";
        public Rubrique()
        {

        }

        public int creerRubrique(string Intitule)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            string req = "insert into dbo.Rubrique (IntituleRubrique) values(@LibelleRubrique)";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@LibelleRubrique", Intitule);
            
            int result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return result;
        }

        public int modifierRubrique(int IdRubrique,string Intitule)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "update dbo.Rubrique set LibelleRubrique= @LibelleRubrique where IdRubrique=@IdRubrique";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@LibelleRubrique", Intitule);
            sqlCommand.Parameters.AddWithValue("@IdRubrique", IdRubrique);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public int modifierRubrique(String Intitule,String NewIntitule)
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "update dbo.Rubrique set LibelleRubrique= @NewLibelleRubrique where LibelleRubrique=@LibelleRubrique";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@LibelleRubrique", Intitule);
            sqlCommand.Parameters.AddWithValue("@NewLibelleRubrique", NewIntitule );
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public int supprimerRubrique(int IdRubrique)
        {

            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Delete From dbo.Rubrique where IdRubrique=@IdRubrique";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@IdRubrique", IdRubrique);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
        public int supprimerRubrique(String Intitule)
        {

            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Delete From dbo.Rubrique where LibelleRubrique=@LibelleRubrique";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@LibelleRubrique", Intitule);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public DataTable listRubriqueAdmin()
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Select * From dbo.Rubrique";
            SqlCommand sqlCommand = new SqlCommand(req,sqlConnection);
            //SqlDataReader reader = sqlCommand.ExecuteReader();


            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dt);

            sqlConnection.Close();

            return dt;
        }

        public SqlDataReader listRubriquePublic()
        {
            SqlConnection sqlConnection = new SqlConnection(cnx);
            sqlConnection.Open();
            String req = "Select * From dbo.Rubrique";
            SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
           
            return reader;
        }
    }
}