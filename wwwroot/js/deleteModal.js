$(document).ready(function () {
    $(".delete-button").on("click", function () {
        var aditivoId = $(this).attr("data-id");
        // Define o ID do aditivo no botão de confirmação
        $("#confirmDelete").attr("data-id", aditivoId); 

        // Faz uma requisição AJAX para obter o conteúdo do PartialView
        $.ajax({
            url: "/Aditivos/Delete/" + aditivoId,
            type: "GET",
            data: { id: aditivoId },
            success: function (result) {
                // Preenche o conteúdo do modal com o PartialView
                $("#deleteModal").find(".modal-body").html(result);
                // Abre o modal de confirmação
                $("#deleteModal").modal("show");
            },
            error: function (xhr, status, error) {
                alert("Ocorreu um erro ao carregar o conteúdo do modal.");
            }
        });
    });

    // Evento de clique do botão de confirmação
    $(document).on("click", "#confirmDelete", function () {
        var aditivoId = $(this).attr("data-id");

        // Faz uma requisição AJAX para deletar o aditivo
        $.ajax({
            url: "/Aditivos/Delete/" + aditivoId,
            type: "POST",
            success: function (result) {
                console.log("uhul");
            },
            error: function (xhr, status, error) {
                // Lógica de erro ao excluir o aditivo
            }
        });


        $("#deleteModal").modal("hide"); // Fecha o modal de confirmação
    });
});
