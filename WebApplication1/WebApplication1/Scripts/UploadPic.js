$(function () {
    $('#file').change(function () {
        var data = new FormData();
        var files = $("#file").get(0).files;

        if (files.length > 0) { data.append("HelpSectionImages", files[0]); }
        else {
            common.showNotification('warning', 'Please select file to upload.', 'top', 'right');
            return false;
        }
        var extension = $("#file").val().split('.').pop().toUpperCase();
        if (extension != "PNG" && extension != "JPG" && extension != "GIF" && extension != "JPEG") {
            alert("Select Image only");
            $("#file").val('');
            common.showNotification('warning', 'Imvalid image file format.', 'top', 'right');
            return false;
        }
        $.ajax({
            url: '../home/SaveProfileImage', type: "POST", processData: false,
            data: data, dataType: 'json',
            contentType: false,
            success: function (response) {
                if (response != null || response != '')
                    alert(response);
                $("#file").val('');
            },
            error: function (er) { }

        });
        return false;
    });

});