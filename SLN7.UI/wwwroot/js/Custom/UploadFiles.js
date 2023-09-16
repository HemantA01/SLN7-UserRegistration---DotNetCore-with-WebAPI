$(document).ready(function () {
    
});

$('#btnUploadImage').click(function () {
    debugger;
    /*var uploadfiles = $('#files123').get(0).files;

    var formData = new FormData();
    for (var i = 0; i < uploadfiles.length; i++) {
        formData.append("files", uploadfiles[i]);
    }     */ 
    var getFile = $('#uploadImage').prop('files')[0];
    var model = new FormData();
    model.append('file', getFile);
    console.log(getFile);
    $.ajax({
        type: 'POST',
        url: '/UploadFile/UploadImage',
        data: model,
        processData: false,
        contentType: false,
        //async: false,
        success: function (response) {
            debugger;
            alert(response);
            if (response == true) {
                alert('Image has been uploaded');
            } else {
                alert('Image not uploaded. Error occured');
            }
            $('#uploadImage').val('');
        },
        error: function (val) {
            debugger;
            console.log('An error occured while uploading image');
        }
    });
});
$('#btnUploadFileDemo').click(function () {
    debugger;
    alert('File Clicked');
    var uploadfiles = $('#files123').get(0).files;

    var formData = new FormData();
    for (var i = 0; i < uploadfiles.length; i++) {
        formData.append("files", uploadfiles[i]);
    }
    $.ajax({
        url: '/UploadFile/UploadFiles',
        type: 'post',
        data: formData,
        processData: false,
        contentType: false,
        //async: false,
        success: function (response) {
            alert('entered in success');
            alert(response.d);
        },
        error: function (resp) {
            alert('error');
        }
    });
});

