$(document).ready(function () {

});
$('#addState').click(function () {
    var btnVal = $('#addState').text();
    switch (btnVal) {
        case "Add States":
            $('#modalleaddiv').modal('show');
            $('#modalTitle').text('Add States');
            break;
        case "Update State":
            
            break;
    }
});
$('#btnCloseM,#btnclose').click(function () {
    $('#modalleaddiv').modal('hide');
});
$('#btnsubmit').click(function () {
    var modTitle = $('#modalTitle').text();
    switch (modTitle) {
        case 'Add States':
            AddState();
            break;
        case "Update States":
            UpdateState();
            break;
    }
});

function AddState() {
    if ($('#ddlCountry').val() == '0') {
        alert('Please select the state');
        return false;
    }
    var val = $("input:radio[name='rbtnstatus']").is(":checked");
    if (val == 0) {
        alert('Please check the state status to true');
        return false;
    }
    if ($('#txtdescription').val().trim() == '') {
        $('#txtdescription').css('border-color', 'red');
        return false;
    }
    var model = new FormData();
    model.append('CountryId', $('#ddlCountry').val());
    model.append('IsActive', $('input[type=radio][name=rbtnstatus] option:selected').val());
    model.append('StateName', $('#txtdescription').val());
    $.ajax({
        type: 'post',
        url: '/StateMaster/AddStates',
        processData: false,
        contentType: false,
        data: model,
        success: function (data) {
            if (data > 0) {
                alert('State has been saved successfully');
                location.reload();
            } else if (data == -2) {
                alert('State name to be entered already exists. Please try with a new name');
                return false;
            }
        },
        error: function (data) {
            alert('error occured');
            return false;
        }
    });
}
$('.stateedit').click(function () {
    debugger;
    $('#addState').text('Update State');
    $('#modalleaddiv').modal('show');
    $('#modalTitle').text('Update States');
    var aa = $(this).closest('tr').find('td:eq(0)').find('#hdnCountryID').val();
    $('#ddlCountry').val(aa);
    $('#txtdescription').val($(this).closest('tr').find('td:eq(1)').text());
    var active = $(this).closest('tr').find('td:eq(2)').text();
    if (active == 'Active') {
        $('input[type=radio][name=rbtnstatus][value=1]').prop('checked', true);
    } else {
        $('input[type=radio][name=rbtnstatus][value=0]').prop('checked', true);
    }
    $('#hdnId').val($(this).closest('tr').find('td:eq(1)').find('#hdnStateID').val());
    $('#hdnCntId').val(aa);
    console.log('StateId: ' + $('#hdnId').val() + '$$CountryId: ' + $('#hdnCntId').val());
});
function UpdateState() {
    if ($('#ddlCountry').val() == '0') {
        alert('Please select the state');
        return false;
    }
    var val = $("input:radio[name='rbtnstatus']").is(":checked");
    if ($('#txtdescription').val().trim() == '') {
        $('#txtdescription').css('border-color', 'red');
        return false;
    }
    var model = new FormData();
    model.append('CountryId', $('#hdnCntId').val());
    model.append('IsActive', $('input[type=radio][name=rbtnstatus]:checked').val() == '1' ? true : false);
    model.append('StateName', $('#txtdescription').val());
    $.ajax({
        type: 'put',
        url: '/StateMaster/UpdateStates?Id=' + $('#hdnId').val() ,
        processData: false,
        contentType: false,
        data: model,
        success: function (data) {
            if (data > 0) {
                alert('State details has been updated successfully');
                location.reload();
            } else if (data == -2) {
                alert('State name to be entered already exists. Please try with a new name');
                return false;
            }
        },
        error: function (data) {
            alert('error occured');
            return false;
        }
    });
}
$('.deleteState').click(function () {
    $('#hdnId').val($(this).closest('tr').find('td:eq(1)').find('#hdnStateID').val());
    $.ajax({
        type: 'delete',
        url: '/StateMaster/DeleteStates?Id=' + $('#hdnId').val(),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data > 0) {
                alert('State has been deleted successfully');
                location.reload();
            } else if (data == -2) {
                alert('error occured while deletion');
                return false;
            }
        },
        error: function (data) {
            alert('error occured');
            return false;
        }
    });
});