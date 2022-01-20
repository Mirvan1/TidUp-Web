
var email = document.getElementById("EMAIL");
var username = document.getElementById("USERNAME");
var pass = document.getElementById("PASSWORD");

var signUp = document.getElementById("signUpIn");
console.log(username);

$(email).




$(document).blur(function enableElement() {

    if (!(email)) {
        email.style.borderColor = "red";
       
      

    }

   else  if (!(username)) {
        username.style.borderColor = "red";


    }
   else  if (!(pass)) {
                pass.style.borderColor = "red";

    }
   
   
    else {
        email.style.borderColor = "blue";
        pass.style.borderColor = "blue";
        username.style.borderColor = "blue";

        signUp.disabled = false;
    }

});