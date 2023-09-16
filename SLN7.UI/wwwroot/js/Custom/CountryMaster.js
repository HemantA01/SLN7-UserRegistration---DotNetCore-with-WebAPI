$(document).ready(function () {
});

$('#addCountry').click(function () {
    if ($('#addCountry').text().trim() == 'Add Countries') {
        AddCountry();
    } else if ($('#addCountry').text().trim() == 'Update Countries') {
        UpdateCountry();
    }
});

function AddCountry() {
    if ($('#txtCountry').val().trim() == '') {
        $('#txtCountry').css('border-color', 'red');
        return false;
    }
    if ($('#txtCountryAbbr').val().trim() == '') {
        $('#txtCountryAbbr').css('border-color', 'red');
        return false;
    }
    if ($('#txtCountryAbbr').val().length != 3) {
        alert('please enter correct country code');
        return false;
    }
    var model = new FormData();
    model.append('CountryName', $('#txtCountry').val().trim());
    model.append('CountryAbb', $('#txtCountryAbbr').val().trim());
    $.ajax({
        type: 'post',
        url: '/CountryMaster/AddCountries',
        data: model,
        processData: false,
        contentType: false,
        success: function (val) {

            if (val == 1) {
                alert('Country added successfully');
                location.reload();
            } else if (val == 2) {
                alert('Country with this name already exists');
            }
        },
        error: function (val) {
            alert('Error occured. Data not saved');
        }
    });
}

function UpdateCountry() {

    if ($('#txtCountry').val().trim() == '') {
        $('#txtCountry').css('border-color', 'red');
        return false;
    }
    if ($('#txtCountryAbbr').val().trim() == '') {
        $('#txtCountryAbbr').css('border-color', 'red');
        return false;
    }
    if ($('#txtCountryAbbr').val().length != 3) {
        alert('please enter correct country code');
        return false;
    }
    var model = new FormData();
    model.append('CountryName', $('#txtCountry').val().trim());
    model.append('CountryAbb', $('#txtCountryAbbr').val().trim());
    model.append('IsActive', ($('input[type=radio][name=rdo1]:checked').val() == '1' ? true : false));
    $.ajax({
        type: 'put',
        url: '/CountryMaster/UpdateCountries?Id='+$('#hdnId').val(),
        data: model,
        processData: false,
        contentType: false,
        success: function (val) {
            if (val == 1) {
                alert('Country details updated successfully');
                location.reload();
            } else if (val == 2) {
                alert('Country with the above details already exists');
            }
        },
        error: function (val) {
            alert('Error occured. Data not saved');
        }
    });
}

$('.deleteCountry').click(function () {
    var getId = $(this).closest('tr').find('td:eq(3)').find('#hdnCountryId').val();
    $.ajax({
        type: 'delete',
        url: '/CountryMaster/DeleteCountries?Id=' + getId,
        processData: false,
        contentType: false,
        success: function (val) {
            if (val == 1) {
                alert('Country deleted successfully');
                location.reload();
            }
        },
        error: function (val) {
            alert('Error occured. Data not saved');
        }
    });
});

$('#txtCountry').keyup(function () {
    if ($('#txtCountry').val().trim() == '') {
        $('#txtCountry').css('border-color', 'red');
        return false;
    } else if ($('#txtCountry').val().trim() != '') {
        $('#txtCountry').css('border-color', '#ced4da');
    }
});

$('#txtCountryAbbr').keyup(function () {
    if ($('#txtCountryAbbr').val().trim() == '') {
        $('#txtCountryAbbr').css('border-color', 'red');
        return false;
    } else if ($('#txtCountryAbbr').val().trim() != '') {
        $('#txtCountryAbbr').css('border-color', '#ced4da');
    }
});

$('.countryedit').click(function () {
    debugger;
    $('#txtCountry').val($(this).closest('tr').find('td:eq(0)').text());
    $('#txtCountryAbbr').val($(this).closest('tr').find('td:eq(1)').text());
    var status = $(this).closest('tr').find('td:eq(2)').text();
    if (status == 'Active') {
        $('input[type=radio][name=rdo1][value=1]').prop('checked', true);
    } else if (status == 'Inactive') {
        $('input[type=radio][name=rdo1][value=0]').prop('checked', true);
    }
    $('#addCountry').text('Update Countries');
    var getId = $(this).closest('tr').find('td:eq(3)').find('#hdnCountryId').val();
    $('#hdnId').val(getId);
    alert($('#hdnId').val());
});