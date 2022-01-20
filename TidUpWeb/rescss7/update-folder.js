var modal = document.getElementById("folder-modal");
/*var btn = document.getElementById("up-folder");*/

function bClUp(p) {

    var modalle = document.getElementById("folder-modal-"+p);
    modalle.style.display = "block";
}
function closeModal(p) {
    var modalle = document.getElementById("folder-modal-" + p);
    modalle.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }

}

