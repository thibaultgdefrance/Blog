﻿
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


function afficherTexte(IdArticle) {
    var textArticle = document.getElementsByClassName("textArticle");
    console.log(textArticle[IdArticle] + IdArticle);
}

function enregistrerCommentaire() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET','\STA6018699\SQLEXPRESS',true);
    xhr.onload();
}

$(document).ready(function () {
    console.log("ok");
    
    
    //var articleTexte = document.getElementsByClassName("textArticle");
   
    //var suite = document.getElementsByClassName("suite");

    //for (var i = 0; i < suite.length; i++) {
        
        
    //    var texte = articleTexte[i];
    //    console.log(texte);
        
    //    suite[i].addEventListener("click", function () {
    //        texte.style.Color = "red";
        
    //        console.log(texte);

    //    });
    //}
});
