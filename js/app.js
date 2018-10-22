
$(".dropdown-trigger").dropdown();



function callParallax() {
  $('.parallax').parallax();
}

window.load = callParallax();

document.addEventListener('DOMContentLoaded', function () {
  var elems = document.querySelectorAll('.sidenav');
  var instances = M.Sidenav.init(elems, {});

});

//$(window).load(function(){
$(document).ready(function(){
  // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
  $('#modal1').modal();
  $('#modal1').modal('open'); 
});