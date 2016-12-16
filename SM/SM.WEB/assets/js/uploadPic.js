$(function () {



    var imgSizeGet = function () {
        return cSize;
    };

    $('#file').change(function () {
        var _URL = window.URL || window.webkitURL;
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

        ///This is for checking H and W if image
        var img;
        var f1 = this.files[0];
        if ((file1 = this.files[0])) {
            img = new Image();
            img.onload = function () {
                //if run with unsuccessful
                if (this.width != 160 && this.height != 170 || (f1.size/1024) > 200) {
                    $("#file").val("");
                    alert("Image has to be Width:160 and Height:170 And less the 50 kb");
                    return false;
                }
                else {
                    //Else Pic will save
                    $("#lodingFile").removeClass("display-none");
                    //$("#profileImgId").addClass("display-none");

                    $.ajax({
                        url: '../Student/SaveProfileImage', type: "POST", processData: false,
                        data: data, dataType: 'json',
                        contentType: false,
                        success: function (response) {
                            if (response != null || response != '') {
                                //alert(response);
                                $("#file").val("");
                                $("#PhotoLocation").val(response.onlyFileName);
                                $("#lodingFile").addClass("display-none");
                                $("#profileImgId").removeClass("display-none");
                                $('#proimg').attr('src', response.filePath);
                            }
                        },
                        error: function (er) {
                            alert("Network too slow " + er);
                        }
                    });
                }
            };
            img.src = _URL.createObjectURL(file1);
        }
        $("#lodingFile").addClass("display-none");
        return false;
    });
});


// This is
//var _URL = window.URL || window.webkitURL;
//$("#file").change(function (e) {
//    var file, img;
//    if ((file = this.files[0])) {
//        img = new Image();
//        img.onload = function () {
//            alert(this.width + " " + this.height);
//            if (this.width >160 && this.height >210) {
//                cSize = false;
//            }
//        };
//        img.src = _URL.createObjectURL(file);
//    }
//});



//This for only getting file name no extention
//String.prototype.filename = function (extension) {
//    var s = this.replace(/\\/g, '/');
//    s = s.substring(s.lastIndexOf('/') + 1);
//    return extension ? s.replace(/[?#].+$/, '') : s.split('.')[0];
//}

////this is for getting file name with extention
//String.prototype.filenameExt = function (extension) {
//    var s = this.replace(/\\/g, '/');
//    s = s.substring(s.lastIndexOf('/') + 1);
//    return s;
//   // return extension ? s.replace(/[?#].+$/, '') : s.split('.')[0];
//}

//this is for calling
//console.log($('img').attr('src').filename());