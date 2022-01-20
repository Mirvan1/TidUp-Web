
var modal_invite = document.getElementById("invite-modal");
/*var btn_invite = document.getElementById("invite-man-a");*/
var span_invite = document.getElementsByClassName("invite-close")[0];
document.getElementById("invite-man-a").onclick = function () {
    modal_invite.style.display = "block";
}
span_invite.onclick = function () {
    modal_invite.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal_invite) {
        modal_invite.style.display = "none";
    }
}//