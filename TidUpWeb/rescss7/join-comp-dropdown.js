function jnCmpFunc() {
  var crt_drp_content=document.getElementById("join-cmp-content");
  crt_drp_content.style.display = "block";

  document.getElementById("jncmp").style.color="gray";
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropJoinBtn')) {
    var dropdowns = document.getElementsByClassName("join-cmp-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}