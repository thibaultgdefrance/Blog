<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Blog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">




    
    <asp:Button ID="btnDeconnexion" runat="server" OnClick="btnDeconnexion_Click" Text="Deconnexion" />
    <asp:Label ID="lbCookie" runat="server"></asp:Label>
    <div class="container-fluid">
        <div class="row">
            
            <div class="panneauGauche col-md-2 offset-md-2">
                <div class="contentGauche">
                    <div class="vignetteGauche">
                        <h3 class="qui">Qui suis-je?</h3>
                        <img class="profil" src="/media/profil.jpg"/>
                        <h4>Jean-Louis</h4>
                        <p>
                            J'ai 34 ans et j'habite dans les Yvelines.
                        </p>
                        <p>
                            
                            Je suis créatrice, styliste et photographe culinaire depuis 2011.
                            
                        </p>
                        <p>
                            
                            J'anime également le blog de cuisine chefnini.com depuis 2008.
                        </p>
                    </div>
                    <div class="vignettePub">
                        <img class="imgPub" src="/media/pub.jpg">
                    </div>
                    <div class="vignetteCategorie">
                        <h3 class="qui">Catégorie</h3>
                        <ul class="listeCategorie">
                            <li><a>Comprendre les bases tecniques</a></li>
                            <li><a>Devenir plus creatif</a></li>
                            <li><a>Mettre en scène</a></li>
                            <li><a>Retoucher ta grand-mère</a></li>
                            <li><a>Savoir composer et cadrer</a></li>
                            <li><a>Trucs&Astuces</a></li>

                        </ul>
                    </div>
                </div>
                
            </div>
            <div class="panneauArticle col-md-5 offset-md-1 pl-0 pr-0">
                <div class="contentDroit ">
                    <div class="vignetteDroite">
                        <div class="photoArticle">

                        </div>
                        <div class="cadreNoir">
                            <div class="vignetteNoire">
                                <p>lorem ipsum</p>
                                <p>lorem ipsum </p>
                                <p>lorem ipsum </p>
                            </div>
                        </div>
                        
                        <div class="contentArticle">
                            <div class="textArticle">
                                <p >
                                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                                </p>
                            </div>
                            
                            <button class="suite" id="suite">lire la suite</button>
                            <hr />
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
            <div class="carouselArticle">

            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12  footer">
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                <img class="imgFooter" src="media/nature.jpg" />
                
            </div>
        </div>
    </div>
    


</asp:Content>
