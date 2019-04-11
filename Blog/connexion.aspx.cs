using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog
{
    public partial class connexion : System.Web.UI.Page
    {

        SqlConnection cnx = new SqlConnection(@"Data Source=STA6018699\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            //string url = HttpContext.Current.Request.Path;
            //Uri uri = new Uri(url);
            //HttpCookie httpCookie = new HttpCookie("emailBlog",TxtbLogin.Text);

        }

        protected void BtnConnexion_Click(object sender, EventArgs e)
        {

            HttpCookie httpCookie = new HttpCookie("emailBlog", TxtbLogin.Text);
            Response.Cookies.Add(httpCookie);
            
            try
            {
                cnx.Open();
                SqlCommand cmdConnexion = new SqlCommand("select IdTypeUtilisateur from dbo.Utilisateur where email=@email And MotDePasse=@Password", cnx);
                cmdConnexion.Parameters.AddWithValue("@email", TxtbLogin.Text);
                cmdConnexion.Parameters.AddWithValue("@Password", TxtbPassword.Text);

                try
                {



                    int typeUtilisateur = Int32.Parse(cmdConnexion.ExecuteScalar().ToString());
                    //int typeUtilisateur = 2;
                    HttpCookie userNiveau = new HttpCookie("userNiveau", typeUtilisateur.ToString());
                    Response.Cookies.Add(userNiveau);




                    if (cbCookie.Checked == true)
                    {

                        if (typeUtilisateur == 2)
                        {
                            Session["email"] = TxtbLogin.Text;
                            Session["niveau"] = typeUtilisateur;
                            //Response.Redirect("/Default.aspx?cookie=true");
                            HttpCookie emailBlog = new HttpCookie("emailBlog",TxtbLogin.Text);
                            emailBlog.Expires = DateTime.Now.AddMonths(1);
                            Request.Cookies.Add(emailBlog);
                            HttpCookie userNiveau2 = new HttpCookie("userNiveau",typeUtilisateur.ToString());
                            userNiveau2.Expires = DateTime.Now.AddMonths(1);
                            Request.Cookies.Add(userNiveau2);
                            Response.Redirect("/Default.aspx");

                        }
                        else
                        {
                            Session["email"] = TxtbLogin.Text;
                            Session["niveau"] = typeUtilisateur;
                            //Response.Redirect("~/admin.aspx?cookie=true");
                            HttpCookie userNiveau2 = new HttpCookie("userNiveau");
                            userNiveau2.Expires = DateTime.Now.AddMonths(1);
                            Request.Cookies.Add(userNiveau2);
                            HttpCookie emailBlog = new HttpCookie("emailBlog", TxtbLogin.Text);
                            emailBlog.Expires = DateTime.Now.AddMonths(1);
                            Request.Cookies.Add(emailBlog);
                            Response.Redirect("/admin.aspx");
                            Cookie truc = new Cookie();
                            truc.supprimerCookies();
                        }

                        //HttpCookie myCookie = new HttpCookie("myCookie", TxtbLogin.Text);
                        ////myCookie.Value = TxtbLogin.Text;
                        //Response.Cookies.Add(myCookie);
                        //myCookie.Expires = DateTime.Now.AddMonths(1);
                        //HttpCookie myCookie2 = new HttpCookie("niveauUser", typeUtilisateur.ToString());
                        //// myCookie2.Value = typeUtilisateur.ToString();
                        //Response.Cookies.Add(myCookie2);
                        //myCookie2.Expires = DateTime.Now.AddMonths(1);
                    }
                    else
                    {
                        if (typeUtilisateur ==2)
                        {
                            Session["email"] = TxtbLogin.Text;
                            Session["niveau"] = typeUtilisateur;
                            
                            
                            HttpCookie userNiveau2 = new HttpCookie("userNiveau");
                            userNiveau2.Expires = DateTime.Now.AddDays(-1);
                            Request.Cookies.Add(userNiveau2);

                            Response.Redirect("/Default.aspx");
                        }
                        else
                        {
                            Session["email"] = TxtbLogin.Text;
                            Session["niveau"] = typeUtilisateur;
                            
                            


                            HttpCookie userNiveau2 = new HttpCookie("userNiveau");
                            userNiveau2.Expires = DateTime.Now.AddDays(-1);
                            Request.Cookies.Add(userNiveau2);

                            Response.Redirect("/admin.aspx");

                        }
                        //Response.Cookies["niveauUser"].Expires = DateTime.Now.AddHours(-1);
                        //Response.Cookies["userEmail"].Expires = DateTime.Now.AddHours(-1);

                    }
                    //        Response.Redirect("/Default.aspx");


                    //         else
                    //        {

                    //            Session["email"] = TxtbLogin.Text;
                    //            Session["niveau"] = typeUtilisateur;
                    //            if (cbCookie.Checked == true)
                    //            {
                    //                HttpCookie myCookie = new HttpCookie("myCookie", TxtbLogin.Text);
                    //                //myCookie.Value = TxtbLogin.Text;
                    //                Response.Cookies.Add(myCookie);
                    //                myCookie.Expires = DateTime.Now.AddMonths(1);
                    //                HttpCookie myCookie2 = new HttpCookie("niveauUser", typeUtilisateur.ToString());
                    //                // myCookie2.Value = typeUtilisateur.ToString();
                    //                Response.Cookies.Add(myCookie2);
                    //                myCookie2.Expires = DateTime.Now.AddMonths(1);
                    //            }
                    //            else
                    //            {
                    //                Response.Cookies["niveauUser"].Expires = DateTime.Now.AddHours(-1);
                    //                Response.Cookies["userEmail"].Expires = DateTime.Now.AddHours(-1);
                    //            }

                    //            Response.Redirect("~/admin.aspx");


                    //        }
                    //        cnx.Close();


                }
               catch (Exception ex)
              {

                   cnx.Close();
                   lbMessage.Text = "vous n'etes pas encore inscrit à notre news letter ?";

              }

            }
            catch (Exception)
        {

            throw;
        }
        }
    }
}
