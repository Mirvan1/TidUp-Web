
var modal = document.getElementById("sign-modal");
var btn = document.getElementById("signbtn");
var span = document.getElementsByClassName("sign-close")[0];
btn.onclick = function() {
  modal.style.display = "block";
}
span.onclick = function() {
  modal.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}