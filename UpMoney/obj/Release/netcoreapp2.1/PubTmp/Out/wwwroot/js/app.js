



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
  var textoOpcao = "";  
  var tipo = tr.getAttribute("data-tipo");

  document.getElementById('valorEditar').value = tr.getAttribute("data-valor");
  document.getElementById('descricaoEditar').value = tr.getAttribute("data-descricao");
  if (tipo === "RECEITA"){
    document.getElementById('dtReceitaEditar').value = tr.getAttribute("data-dtReceita");
    document.getElementById('idReceitaFormEditar').value = tr.getAttribute("data-idReceita");
  }else{
    document.getElementById('dtDespesaEditar').value = tr.getAttribute("data-dtDespesa");
    document.getElementById('idDespesaFormEditar').value = tr.getAttribute("data-idDespesa");

  } 
  
  textoOpcao = tr.getAttribute("data-descricaoTipoReceita");
  
  const selectedCategory = document.querySelector('#tipoReceitaEditar');
  
  const materializeSelectedCategory = M.FormSelect.init(selectedCategory);


  if(typeof(Event) === 'function') {
      var event = new Event('change');
  }else{
      var event = document.createEvent('Event');
      event.initEvent('change', true, true);
  }

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

function ExcluirDespesa(numero){
  var url = window.location.origin + "/Despesa/ExcluirDespesa/" + numero;
  window.location.href = url;

}




function mudaCorModal(cor){
  //debugger
  //document.getElementById("tituloModal").innerHTML = "";
  

  // if(cor === 'Despesa'){    

  // document.getElementById("tituloModal").innerHTML = ""+"Despesas";  
  // document.getElementById("corModal").style.backgroundColor = "#e53935";    
  // document.getElementById("tituloModal").style.color = "#ffffff";
  
  // }
  // else{  
  // document.getElementById("tituloModal").innerHTML = ""+"Receitas";
  // document.getElementById("corModal").style.backgroundColor = "#81c784";    
  // document.getElementById("tituloModal").style.color = "#ffffff";
  // }

  // document.addEventListener('DOMContentLoaded', function() {
  // var elems = document.querySelectorAll('.modal2');
  // var elems1 = document.querySelectorAll('.modal1');
  // var instances = M.Modal.init(elems,elems1, {});


//});

// if(document.getElementById("tituloModal").innerHTML === "Despesas"){
//   document.getElementById("corModal").style.backgroundColor = "#e53935";
// }else
//   //(document.getElementById("tituloModal").innerHTML === "Receitas"){
//   document.getElementById("corModal").style.backgroundColor = "#81c784";

}




