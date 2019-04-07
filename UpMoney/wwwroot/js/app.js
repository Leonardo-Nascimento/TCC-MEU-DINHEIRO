
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


  var elems = document.querySelectorAll('.parallax');
  var instances = M.Parallax.init(elems, 100);

//BOTÃO FLUTUANTE//
  var elems = document.querySelectorAll('.fixed-action-btn');
  var instances = M.FloatingActionButton.init(elems, { hoverEnabled: false });

//BOTÃO DROPDOWN//
  var elems = document.querySelectorAll('.dropdown-trigger');
  var instances = M.Dropdown.init(elems, {});

//EFEITO COLLAPSIBLE DO MENU LATERAL//

  var elems = document.querySelectorAll('.collapsible');
  var instances = M.Collapsible.init(elems, {});


//EFEITO DO CALENDÁRIO//

  var elems = document.querySelectorAll('.datepicker');
  var instances = M.Datepicker.init(elems, {
    format: 'dd/mm/yyyy'
  });


//EFEITO SELECT DOS FILTROS//

  var elems = document.querySelectorAll('select');
  var instances = M.FormSelect.init(elems, {});

//Modals//

  var elems = document.querySelectorAll('.modal');
  var instances = M.Modal.init(elems, {});

  var btnReceita = document.querySelectorAll("[data-bteditar]");

btnReceita.forEach(el => el.addEventListener("click", () => {
  getDetalhes(el);
  M.updateTextFields();
  
 
}));


function getDetalhes(element) {
  debugger
  var tr = element.parentNode.parentNode;
  document.getElementById('valorEditar').value = tr.getAttribute("data-valor");
  document.getElementById('descricaoEditar').value = tr.getAttribute("data-descricao");
  document.getElementById('dtReceitaEditar').value = tr.getAttribute("data-dtReceita");    
  document.getElementById('tipoReceitaEditar').value = tr.getAttribute("data-TipoReceita");
  document.getElementById("opcao").value = 
}

});


function selectoption() {
  
  var valor = document.getElementById("opcao").value;

  if (valor !== "2") {
    document.getElementById("intervaloData").style.display = 'none';
  }
  else {
    document.getElementById("intervaloData").style.display = 'block';
  }

  opcaoPesquisa(valor);

}


function opcaoPesquisa(numero) {
  if (numero != 2) {
    var url = window.location.origin + "/Receita/VerReceita/" + numero;

    window.location.href = url;
  }

}


function ExcluirRceita(numero){

  var url = window.location.origin + "/Receita/ExcluirReceita/" + numero;

  window.location.href = url;

}