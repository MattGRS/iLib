var campoPesquisa = document.querySelector("#pesquisa");

campoPesquisa.addEventListener("input", function () {
    console.log(this.value);
    var buscas = document.querySelectorAll(".busca");
    for (var i = 0; i < buscas.length; i++) {
        var busca = buscas[i];
        var tdNome = busca.querySelector(".info-nome");
        var nome = tdNome.textContent;
        var expressao = new RegExp(this.value, "i");

        if (!expressao.test(nome)) {
            busca.classList.add("some")
        } else {
            busca.classList.remove("some")
        }

        if (campoPesquisa.value == "") {
            busca.classList.remove("some")
        }
    }
});