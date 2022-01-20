function crtCmpFunc() {
  var crt_drp_content=document.getElementById("create-cmp-content");
  crt_drp_content.style.display = "block";

  document.getElementById("crtcmp").style.color="gray";
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropCreateBtn')) {
    var dropdowns = document.getElementsByClassName("create-cmp-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}