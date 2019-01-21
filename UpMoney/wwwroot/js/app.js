
//$(".dropdown-trigger").dropdown();



//function callParallax() {
//  $('.parallax').parallax();
//}

//window.load = callParallax();

////$(window).load(function(){
//$(document).ready(function(){
//  // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
//  $('#modal1').modal();
//  $('#modal1').modal('open'); 
//});

//MENU LATERAL//
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.sidenav');
    var instances = M.Sidenav.init(elems, {});

});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.parallax');
    var instances = M.Parallax.init(elems, 100);
});

//BOTÃO FLUTUANTE//
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.fixed-action-btn');
    var instances = M.FloatingActionButton.init(elems, { hoverEnabled: false });
});

//CALENDARIO//
document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.datepicker');
    var instances = M.Datepicker.init(elems, options);
  });

  //BOTÃO DROPDOWN//
  document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems,  { });    
  });

