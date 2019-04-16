
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

$(document).ready(function () {
    console.log("ok");

    var suite = document.getElementsByClassName("suite");
    
    var articleTexte = document.getElementsByClassName("textArticle");

//$("span.suite").each(function () {
//    console.log($(this));
//});

    for (var i = 0; i < suite.length; i++) {

        console.log(suite[i]+i);
        
        suite[i].addEventListener("click", function () {

            articleTexte
            //for (var j = 0; j < t.length; j++) {
            //    t[j].style.backgroundColor = "red";

            //}

        });
}
});
