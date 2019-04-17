﻿using System;
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
        int IdArticle = 0;
        int IdStatut = 0;
        int IdAuteur = 0;


        
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

        public List<Commentaire> listeCommentaire(int IdArticle)
        {
            List<Commentaire> listeCommentaires = new List<Commentaire>();
            try
            {
                
                SqlConnection sqlConnection = new SqlConnection(cnx);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.Commentaire where IdArticle=@IdArticle order by DatePublication DESC ", sqlConnection);
                cmd.Parameters.AddWithValue("@IdArticle",IdArticle);
                SqlDataReader reader = cmd.ExecuteReader();
                 
                while (reader.Read())
                {
                    Commentaire commentaire = new Commentaire();
                    commentaire.IdCommentaire = Int32.Parse(reader[0].ToString());
                    commentaire.TitreCommentaire = reader[1].ToString();
                    commentaire.TexteCommentaire = reader[2].ToString();
                    commentaire.DatePublication = reader[3].ToString();
                    commentaire.DateModification = reader[4].ToString();
                    commentaire.Popularite = Int32.Parse(reader[5].ToString());
                    commentaire.IdArticle = Int32.Parse(reader[6].ToString());
                    commentaire.IdStatut = Int32.Parse(reader[7].ToString());
                    commentaire.IdAuteur = Int32.Parse(reader[8].ToString());


                    listeCommentaires.Add(commentaire);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listeCommentaires;
        }


    }

    
}