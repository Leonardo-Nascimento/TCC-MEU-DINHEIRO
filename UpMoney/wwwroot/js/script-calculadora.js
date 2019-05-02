 /*-----------------------------------------CALCULADORA----------------------------------------------------------*/
// pego os elementos li e div input
var btn 	  = document.querySelectorAll(".key li"),
	input 	  = document.querySelector(".input-valor"),
	operador  = document.querySelectorAll(".operador");

// Percorro o array para usar todas as informações
for(var i = 0; i < btn.length; i++){
	document.onkeypress = function(){
		var key = event.keyCode;
		//console.log(key);
		for(var e = 0; e <= 10; e++){
			if(key === (48+e)){
                debugger
				input.innerHTML += e;
                document.querySelector("[id='valor_inline']").value += e;
			}
		}
		switch (key){
			case 42:
				input.innerHTML += "*";
                document.querySelector("[id='valor_inline']").value = input.innerText;
				break;
			case 43:
				input.innerHTML += "+";
                document.querySelector("[id='valor_inline']").value = input.innerText;
				break;
			case 45:
				input.innerHTML += "-";
                document.querySelector("[id='valor_inline']").value = input.innerText;
				break;
			case 46:
				input.innerHTML += ".";
                document.querySelector("[id='valor_inline']").value = input.innerText;
				break;
			case 47:
				input.innerHTML += "/";
                document.querySelector("[id='valor_inline']").value = input.innerText;
				break;
			case 13:
			case 61:
				var equacao = input.innerHTML;
				if(equacao){
					try {
                        debugger
						input.innerHTML = eval(equacao);
                        document.querySelector("[id='valor_inline']").value = eval(equacao);
					} catch (e) {
						alert('Erro na expressão');

					} 
				}
				break;
			case 67:
			case 99:
				input.innerHTML = "";
				break;						
			default:
				//console.log("Procurando erros?");
				break;
		}
	};
	btn[i].addEventListener('click',function(){
		var btnVal 	 = this.innerHTML,
			inputVal = input.innerHTML;
		//console.log(btnVal);

		// crio um clear caso o c for clicado
		switch (btnVal){
			case "c":
            debugger
				input.innerHTML = "";
                document.querySelector("[id='valor_inline']").value = "";
				break;
			case "=":
				// Crio a variável de equação aqui eu utilizo a função eval do javascript
				var equacao = inputVal;
				
				if(equacao){
					try {
                        debugger
						input.innerHTML = eval(equacao);
                        document.querySelector("[id='valor_inline']").value = eval(equacao);
					} catch (e) {
						alert('Erro na expressão');

					} 
				}
				break;
			default:
				input.innerHTML += btnVal;
               
                document.querySelector("[id='valor_inline']").value += btnVal;
				break;	
		}

	});
}