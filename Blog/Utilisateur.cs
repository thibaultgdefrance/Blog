using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog
{
    public class Utilisateur
    {
        public Utilisateur()
        {

        }
        string cnx = @"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void creerUtilisateur(string Nom,string Prenom,string email,string MotDePasse,int Blacklist,int IdTypeUtilisateur)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.Utilisateur(Nom,Prenom,email,MotDePasse,Blacklist,IdTypeUtilisateur)values(@Nom,@Prenom,@email,@MotDePasse,@Blacklist,@IdTypeUtilisateur)", sqlConnection);
                cmd.Parameters.AddWithValue("@Nom",Nom);
                cmd.Parameters.AddWithValue("@Prenom", Prenom);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@MotDePasse", MotDePasse);
                cmd.Parameters.AddWithValue("@Blacklist",Blacklist );
                cmd.Parameters.AddWithValue("@IdTypeUtilisateur", IdTypeUtilisateur);
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void modifierUtilisateur()
        {

        }

        public void supprimerUtilisateur(int IdUtilisateur)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Delete From dbo.Utilisateur where IdUtilisateur=@IdUtilisateur",sqlConnection);
                cmd.Parameters.AddWithValue("@IdUtilisateur", IdUtilisateur);
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}