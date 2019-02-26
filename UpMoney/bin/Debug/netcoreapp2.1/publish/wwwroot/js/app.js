
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

  //BOTÃO DROPDOWN//
  document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems,  { });    
  });

//EFEITO COLLAPSIBLE DO MENU LATERAL//

document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems, {});
  });


  //EFEITO DO CALENDÁRIO//

  document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.datepicker');
    var instances = M.Datepicker.init(elems, {
        format: 'dd/mm/yyyy'
    });    
  });


  //EFEITO SELECT DOS FILTROS//

  document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems, {});
  });

//Modals//

  document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.modal');
    var instances = M.Modal.init(elems, {});
  });


function selectoption(){
  debugger
    var valor = document.getElementById("opcao").value;

    if (valor !== "2")
        document.getElementById("intervaloData").style.display = 'none';
    else
        document.getElementById("intervaloData").style.display = 'block';
    
        opcaoPesquisa(valor);
  
}


function opcaoPesquisa(numero){
 
 alert("window.location.href = ../Receita/VerReceita/"+ numero);

 window.location.href = "../Receita/VerReceita/" + parseInt(numero);

  //href="../Receita/VerReceita";
}


