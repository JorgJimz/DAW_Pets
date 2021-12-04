// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url) => {
    $.ajax({
        type: 'GET',
        url: url,
        beforeSend: function () {
            $('.loader').css('display','block');
        },
        success: function (res) {
            $('.loader').css('display','none');
            $('#DetailsModal .modal-content').html(res);
            $('#DetailsModal').modal('show');
        }
    })
}