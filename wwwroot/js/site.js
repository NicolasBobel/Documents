function Cadastro(evt) {
  console.log(evt);

  if ($("#titulo").val() == "") {
    alert("titulo não informado");
    evt.preventDefault();
  } else if ($("#categoria").val() == "") {
    alert("categoria não informada");
    evt.preventDefault();
  } else if ($("#processo").val() == "0") {
    alert("processo não informado");
    evt.preventDefault();
  } else if ($("#codigo").val() == "0") {
    alert("codigo não informado");
    evt.preventDefault();
  }
}

$("#frm").on("submit", Cadastro);
