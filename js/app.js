
$(".dropdown-trigger").dropdown();



function callParallax() {
  $('.parallax').parallax();
}

window.load = callParallax();

document.addEventListener('DOMContentLoaded', function () {
  var elems = document.querySelectorAll('.sidenav');
  var instances = M.Sidenav.init(elems, {});

});