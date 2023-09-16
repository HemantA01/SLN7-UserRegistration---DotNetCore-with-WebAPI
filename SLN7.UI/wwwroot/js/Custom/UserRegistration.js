


$(document).ready(function () {
    //var $j = jQuery.noConflict();
    $('.user-date-inp').datepicker({
        Date: new Date(),
        changeMonth: true,
        changeYear: true
    });
    debugger;
    var url = window.location.pathname.split('/')[3];
    if (url != 'undefined' && url != null) {
        GetParticularUserDetail(url);
    }

});
$('#btnRegisterUser').click(function () {
    alert('registration start');
    debugger;
    var gender = $('input[type=radio][name=rdoGender]:checked').val();
    if (gender == 'M') {
        gender = 'Male';
    } else if (gender == 'F') {
        gender = 'Female';
    }
    var model = new FormData();
    model.append('UserFname', $('#txtUserFName').val());
    model.append('UserLname', $('#txtUserLName').val());
    model.append('UserEmail', $('#txtUserEmail').val());
    model.append('UserContact', $('#txtUserMobile').val());
    model.append('DOB', $('#txtDOB').val());
    model.append('Age', $('#txtAge').val());
    model.append('Gender', gender);
    model.append('Nationality', $('#txtNationality').val());
    model.append('TemporaryAddress', $('#txtTempAddress').val());
    model.append('PermanentAddress', $('#txtPAddress').val());
    model.append('CountryId', $('#ddlCountry option:selected').val());
    model.append('StateId', $('#ddlState option:selected').val().split('^')[1]);
    model.append('City', $('#txtCity').val());
    var file = $('#flUpload')[0];
    if (file != null) {
        model.append('ProfileImage', file.files[0]);
    } else {
        model.append('ProfileImage', file);
    }
    console.log(file.files[0]);
    if ($('#btnRegisterUser').text() == 'Add New User') {
        $.ajax({
            type: 'post',
            url: '/UserRegistration/AddNewUser',
            data: model,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data == 1) {
                    alert('Record inserted successfully');
                    clearFields();
                    window.location.href = '/UserRegistration/GetUsersList';
                }
            },
            error: function (err) {
                alert('error occured');
            }
        });
    }
});

$('#txtDOB').on('blur', function () {
    //debugger;
    calculateAge();
});
function calculateAge() {
    if ($('#txtDOB').val().trim() != '') {
        var today = new Date();
        var birthDate = new Date($('#txtDOB').val());
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        $('#txtAge').val(age);
    }
}
$('#chkSameAddress').click(function () {
    if ($(this).prop("checked") == true) {
        var tempAdd = $('#txtTempAddress').val();
        $('#txtPAddress').val(tempAdd);
        $('#txtPAddress').attr('disabled', 'disabled');
    }
    else if ($(this).prop("checked") == false) {
        $('#txtPAddress').val('');
        $('#txtPAddress').removeAttr('disabled')
    }
});
function clearFields() {
    $('#txtUserFName').val('');
    $('#txtUserLName').val('');
    $('#txtUserEmail').val('');
    $('#txtUserMobile').val('');
    $('#txtDOB').val('');
    $('#txtAge').val('');
    $('input:radio[name=rdoGender][id=rdoMale]').prop('checked', true);
    $('#txtNationality').val('');
    $('#txtTempAddress').val('');
    $('#txtPAddress').val('');
    $('#ddlCountry').val('0');
    $('#ddlState').val('0');
    $('#txtCity').val('');
}

function GetParticularUserDetail(userId) {
   // debugger;
    //alert('UID: ' + userId);
    $.ajax({
        type: 'get',
        url: '/UserRegistration/GetUserDetailsById?userId=' + userId,          
        processData: false,
        contentType: false,
        async: false,
        success: function (data) {
           // debugger;
            console.log(data);
            console.log(data.newUserRegistration);
            if (data['newUserRegistration'] == null) {
                alert('Unable to retrive the data. Please try again');
                return false;
            } else {
                BindFormWithUserDetails(data['newUserRegistration']);
            }
            
            return false;
        },
        error: function (xhr) {
            //debugger;
            alert('Error occured while retrieving data');
            return false;
        }
    });
}

function GetUSerById() {
    //get uid from url
    //then call ajax
    //then call bind method
}
function BindFormWithUserDetails(data) {
   // debugger;
    console.log(data);
    var dt = moment(data.dob).format('MM/DD/yyyy');
    $('#txtUserFName').val(data.userFname.trim());
    $('#txtUserLName').val(data.userLname.trim());
    $('#txtUserEmail').val(data.userEmail.trim());
    $('#txtUserMobile').val(data.userContact.trim());
    $('#txtDOB').val(dt);
    calculateAge();
    $('input[type=radio][name=rdoGender][value=' + data.gender.trim() + ']').prop('checked', true);
    $('#txtNationality').val(data.nationality.trim());
    if (data.temporaryAddress.trim() == data.permanentAddress.trim()) {
        $('#chkSameAddress').prop('checked', true);
    } else {
        $('#chkSameAddress').prop('checked', false);
    }
    $('#txtTempAddress').val(data.temporaryAddress.trim());
    $('#txtPAddress').val(data.permanentAddress.trim());
    $('#ddlCountry').val(data.countryId);
    $('#ddlState').val(data.countryId+'^'+data.stateId);
    $('#txtCity').val(data.city.trim());
    $('#hdnGetUserId').val(data.userId);
    $('#btnRegisterUser').text('Update Existing User');
    console.log('hdn userid: ' + $('#hdnGetUserId').val());
}


