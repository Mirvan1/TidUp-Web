
var folderadd_modal = document.getElementById("addfolder-modal");
var folderadd_btn = document.getElementById("addfolderbtn");
var folderadd_span = document.getElementsByClassName("addfolder-close")[0];
folderadd_btn.onclick = function () {
    folderadd_modal.style.display = "block";
}
folderadd_span.onclick = function () {
    folderadd_modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == folderadd_modal) {
        folderadd_modal.style.display = "none";
    }
}