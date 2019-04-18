
function verifier(id, LabelId,typeVerif,btnSubmit) {
    
    var txt = $("#MainContent_" + id).val();
    $("#MainContent_" + LabelId).html("");
    if (txt == "" || txt.length == 1) {
        $("#MainContent_" + LabelId).html("veillez vérifier les champs");
    } else if (typeVerif=="email") {
        if (!validateEmail()) {
            $("#MainContent_" + LabelId).html("champ email n'est pas valide");
        }
        
    }
    else {
        $("#MainContent_" + LabelId).html("");
        $("#MainContent_" + btnSubmit).removeAttr("disabled");
    }
}

//alert("ok");

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}


var accueil = document.getElementsByTagName;
var contact = document.getElementById("contact");
var connection = document.getElementById("connexion");
var accueil = document.getElementById("accueil");

//accueil.addEventListener("Click", redirect("Default.aspx"),true);
//connection.addEventListener("click", redirect("connexion.aspx"),true);



function redirect(url) {
    window.location.replace(url);
}


function afficherTexte(IdArticle2) {
    var a = document.getElementById("MainContent_texteComplet" + IdArticle2);
    if (a.style.display == "block") {
        a.style.display = "none";
    } else {
        a.style.display = "block";
    }
    
    
    console.log(a);
    
}

function enregistrerCommentaire(IdArticle) {
    //var xhr = new XMLHttpRequest();
    //xhr.open('GET','\STA6018699\SQLEXPRESS',true);
    //xhr.onload(function () {
        
    //});
    //xhr.send();
    //Response.Redirect("ListeDesCommentaire.aspx ?IdArticle=" + IdArticle + "titreCommentaire=" + titreCommentaire + "textCommentaire=" + textCommentaire);
    //$.ajax; {
    //    Response.Redirect("ListeDesCommentaire.aspx ?IdArticle=" + IdArticle + "?titreCommentaire=" + titreCommentaire + "?textCommentaire=" + textCommentaire+"?Login="+email+"?password="+password+);
    //    url = ListeDesCommentaires.aspx;

    //}
    var login = $(".Login" + IdArticle);
    var password = $(".Password" + IdArticle);
    var titre = $(".Titre" + IdArticle);
    var texte = $(".texteCommentaire" + IdArticle);
    var IdArticle2 = IdArticle;

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            if (xhttp.responseText=="ok") {

            }
        }
    }
    xhttp.open("GET", "ListeDesCommentaires.aspx?titre=" + titre + "&texte=" + texte + "&login=" + login + "&password=" + password + "&IdArticle2" + IdArticle2 +"", true);
    xhttp.send();
}

$(document).ready(function () {
   
    
    
   
});
