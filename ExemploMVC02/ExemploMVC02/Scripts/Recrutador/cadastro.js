function validarFormulario()
{
    var textoCampoNome = document.getElementById("campo-nome").value;
    var textoCampoCPF = document.getElementById("campo-cpf").value;
    var textoCampoTempoEmpresa = document.getElementById("campo-tempo-empresa").value;

    var quatitadadeCaracterCampoNome = textoCampoNome.lenght;
    
    if(quatitadadeCaracterCampoNome < 7 || quatitadadeCaracterCampoNome> 100)
    {
        alert("Campo nome deve conter no mínimo 7 caracteres e no máximo 100 caracteres");
    }
}