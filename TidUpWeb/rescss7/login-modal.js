
var sign_modal = document.getElementById("login-modal");
var sign_btn = document.getElementById("lgnbtn");
var sign_span = document.getElementsByClassName("login-close")[0];
sign_btn.onclick = function() {
  sign_modal.style.display = "block";
}
sign_span.onclick = function() {
  sign_modal.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == sign_modal) {
    sign_modal.style.display = "none";
  }
}