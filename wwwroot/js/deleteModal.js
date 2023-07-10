$(document).ready(function () {
    $(".delete-button").on("click", function () {
        var dataId = $(this).attr("data-id");
        var dataUrl = $(this).attr("data-url");

        // Define o ID do botão de confirmação
        $("#confirmDelete").attr("data-id", dataId);

        // Faz uma requisição AJAX para obter o conteúdo do PartialView
        $.ajax({
            url: dataUrl + "/" + dataId,
            type: "GET",
            data: { id: dataId },
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
        var dataId = $(this).attr("data-id");
        var dataUrl = $(this).attr("data-url");

        // Faz uma requisição AJAX para deletar o aditivo
        $.ajax({
            url: dataUrl + "/" + dataId,
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
