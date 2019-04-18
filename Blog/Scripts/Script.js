
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



function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}


var accueil = document.getElementsByTagName;
var contact = document.getElementById("contact");
var connection = document.getElementById("connexion");
var accueil = document.getElementById("accueil");




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
    
    
   
    
}

function enregistrerCommentaire(IdArticle) {

    


    var login = $(".Login" + IdArticle).val();
    var password = $(".Password" + IdArticle).val();
    var titre = $(".Titre" + IdArticle).val();
    var texte = $(".texteCommentaire" + IdArticle).val();
    var IdArticle2 = IdArticle;

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            if (xhttp.responseText == "ok") {

                var newComment = "<div class='com'>< span class='titreDeCommentaire' > génial :</span > <span class='textDeCommentaire'>j'ai trouvé cet article génial, continué comme ça!</span> <span class='dateCommentaire'>ajouter le 18/04/2019 00:00:00</span></div >"
                
                $(".blocCommentaire" + IdArticle).html($(".blocCommentaire" + IdArticle).html() + newComment);

            }
        }
    }
    xhttp.open("GET", "ListeDesCommentaires.aspx?titre=" + titre + "&texte=" + texte + "&login=" + login + "&password=" + password + "&IdArticle2=" + IdArticle2 +"", true);
    xhttp.send();
}

$(document).ready(function () {
   
    
    
   
});
