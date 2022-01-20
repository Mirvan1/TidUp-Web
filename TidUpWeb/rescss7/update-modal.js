
var modal_item = document.getElementById("update-modal");
var btn_item = document.getElementById("updatebtn");
var span_item = document.getElementsByClassName("update-close")[0];
btn_item.onclick = function () {
    modal_item.style.display = "block";
}
span_item.onclick = function () {
    modal_item.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal_item) {
        modal_item.style.display = "none";
    }
}