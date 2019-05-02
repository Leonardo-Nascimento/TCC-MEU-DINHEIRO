



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
  
  var tr = element.parentNode.parentNode;
  var textoOpcao = "";
  var idOpcao;

  document.getElementById('valorEditar').value = tr.getAttribute("data-valor");
  document.getElementById('descricaoEditar').value = tr.getAttribute("data-descricao");
  document.getElementById('dtReceitaEditar').value = tr.getAttribute("data-dtReceita");
  debugger    
  document.getElementById('idReceitaFormEditar').value = tr.getAttribute("data-idReceita");    
  
  
  textoOpcao = tr.getAttribute("data-descricaoTipoReceita");
  idOpcao = tr.getAttribute("data-idtiporeceita");



  const selectedCategory = document.querySelector('#tipoReceitaEditar');
  debugger
  const materializeSelectedCategory = M.FormSelect.init(selectedCategory);


  selectedCategory.value = idOpcao;
  if(typeof(Event) === 'function') {
      var event = new Event('change');
  }else{
      var event = document.createEvent('Event');
      event.initEvent('change', true, true);
  }
  selectedCategory.dispatchEvent(event);
  

    }
  }
);

function SelectTipoReceita(){
  debugger
  var tipoDespesa = document.getElementById("TiposReceitas").options[document.getElementById("TiposReceitas").selectedIndex].text;
  document.getElementById(tipoDespesa).selected = "true";  
}


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

