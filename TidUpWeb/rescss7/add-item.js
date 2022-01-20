
var additem_modal = document.getElementById("additem-modal");
var additem_btn = document.getElementById("additembtn");
var additem_span = document.getElementsByClassName("additem-close")[0];
additem_btn.onclick = function () {
    additem_modal.style.display = "block";
}
additem_span.onclick = function () {
    additem_modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == additem_modal) {
        additem_modal.style.display = "none";
    }
}