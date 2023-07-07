$(document).ready(function () {
    $(".delete-button").on("click", function () {
        var aditivoId = $(this).attr("data-id");
        // Define o ID do aditivo no bot�o de confirma��o
        $("#confirmDelete").attr("data-id", aditivoId); 

        // Faz uma requisi��o AJAX para obter o conte�do do PartialView
        $.ajax({
            url: "/Aditivos/Delete/" + aditivoId,
            type: "GET",
            data: { id: aditivoId },
            success: function (result) {
                // Preenche o conte�do do modal com o PartialView
                $("#deleteModal").find(".modal-body").html(result);
                // Abre o modal de confirma��o
                $("#deleteModal").modal("show");
            },
            error: function (xhr, status, error) {
                alert("Ocorreu um erro ao carregar o conte�do do modal.");
            }
        });
    });

    // Evento de clique do bot�o de confirma��o
    $(document).on("click", "#confirmDelete", function () {
        var aditivoId = $(this).attr("data-id");

        // Faz uma requisi��o AJAX para deletar o aditivo
        $.ajax({
            url: "/Aditivos/Delete/" + aditivoId,
            type: "POST",
            success: function (result) {
                console.log("uhul");
            },
            error: function (xhr, status, error) {
                // L�gica de erro ao excluir o aditivo
            }
        });


        $("#deleteModal").modal("hide"); // Fecha o modal de confirma��o
    });
});
