$(document).ready(function () {

});

function addLeadSource(type, id, text, isActive) {
    switch (type) {
        case 'Add':
            $('#modalleaddiv').modal('show');
            $('#modalTitle').text('Add Lead Source');
            $('#lblactive').text('Active');
            $('#lblinactive').text('Inactive');
            $('#lbldescription').text('Enter description');
            $('#txtdescription').attr('Enter Lead source details');
            $('#btnsubmit').text('Add Lead Source');
            break;
        case 'Update':
           // debugger;
            $('#modalleaddiv').modal('show');
            $('#modalTitle').text('Update Lead Source');
            $('#lblactive').text('Active');
            $('#lblinactive').text('Inactive');
            if (isActive == 'Active') {
                $('input[type=radio][name=rbtnstatus][value=1]').prop('checked', true);
            } else if (isActive == 'Inactive') {
                $('input[type=radio][name=rbtnstatus][value=2]').prop('checked', true);
            }
            $('#hdnId').val(id);
            $('#lbldescription').text('Enter description');
            $('#txtdescription').val(text);
            //$('#txtdescription').attr('Enter Lead source details');
          //  var currentRow = $(this).closest("tr");

            //var getname = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
        //    var col1 = currentRow.find("td:eq(0)").text();
            /*$('#txtdescription').val(col1);*/
          //  alert(col1);
            //getLeadName();
            $('#btnsubmit').text('Update Lead Source');
            break;
    }
    
}
$('#btnsubmit').click(function () {
    var leadTitle = $('#modalTitle').text();
    switch (leadTitle) {
        case 'Add Lead Source':
            AddLeadSource();
            break;
        case 'Update Lead Source':
            UpdateLeadSource();
            break;
    }
});

function AddLeadSource() {
   // debugger;
    var leadsrc = $('#txtdescription').val();
    if (leadsrc == null || leadsrc == undefined || leadsrc == '') {
        $('#spnValidate').text('Please enter lead source name');
        //showToastrMsg('error', 'Please enter lead source name');
        return false;
    }
    var model = new FormData();
    model.append('LeadSourceText', leadsrc);
    model.append('LeadSourceStatus', ($('input[type=radio][name=rbtnstatus]:checked').val()=='1'?true:false));
    $.ajax({
        type: 'post',
        url: '/LeadSource/AddLeadSource',
        processData: false,
        contentType: false,
        data: model,
        success: function (response) {
            /*switch (response) {
                case 1:
                    $("#btnclose").click();
                    location.reload();
                    break;
                case 2:
                    showToastrMsg("error", "You can't add duplicate lead.");
                    break;
                case 3:
                    showToastrMsg("error", "No lead found.", "Please try after some time.");
                    setTimeout(function () {
                        location.reload();
                    }, 5000);
                    break;
                case 0:
                    showToastrMsg("error", "Unable to add lead.", "Please try after some time.");
                    setTimeout(function () {
                        location.reload();
                    }, 5000);
                    break;
                default:
                    showToastrMsg("error", "Unable to add lead. Please try after some time.");
                    setTimeout(function () {
                        location.reload();
                    }, 5000);
                    break;
            }*/
            var data = response;
            alert(data);
            location.reload();
        },
        error: function (msg) {
            /*showToastrMsg("error", "Unable to add lead. Please try after some time.");
            setTimeout(function () {
                location.reload();
            }, 5000);*/
            alert('error occured');
            
        }
    });
}

$('#btnclose,#btnCloseM').click(function () {
    $('#modalleaddiv').modal('hide');
    $('#modalTitle').text('');
    $('#lblactive').text('');
    $('#lblinactive').text('');
    $('#lbldescription').text('');
    $('#txtdescription').attr('');
    $('#btnsubmit').text('');
});

function getSelectedLeadById(id, isActive) {
    alert(id + '++' + isActive);
    $('#modalleaddiv').modal('show');
    
    var getname = $(this).closest('tr').find('td:eq(0)').val();
    $('#txtdescription').val(getname);
}

function getLeadName() {
   // debugger;
    $('.leadedit').click(function () {
        debugger;
        var currentRow = $(this).closest("tr").find('td:eq(0)').text();
       // alert(currentRow);
        $('#txtdescription').val(currentRow);
        return false;
    });

}

function UpdateLeadSource() {
   // debugger;
    var leadsrc = $('#txtdescription').val();
    if (leadsrc == null || leadsrc == undefined || leadsrc == '') {
        $('#spnValidate').text('Please enter lead source name');
        //showToastrMsg('error', 'Please enter lead source name');
        return false;
    }
    var model = new FormData();
    model.append('LeadSourceID', $('#hdnId').val());
    model.append('LeadSourceText', leadsrc);
    model.append('LeadSourceStatus', ($('input[type=radio][name=rbtnstatus]:checked').val() == '1' ? true : false));
    $.ajax({
        type: 'put',
        url: '/LeadSource/UpdateLeadSource?LeadSrcId=' + $('#hdnId').val(),
        processData: false,
        contentType: false,
        data: model,
        success: function (response) {
            var data = response;
            alert(data);
            if (data == 1) {
                alert('Lead updated successfully');
            } else if (data == 2) {
                alert('Lead already exists with same status');
            }
            location.reload();
        },
        error: function (msg) {
            alert('error occured');

        }
    });
}

$('.deleteLeadSrc').click(function () {
    var leadId = $(this).closest('tr').find('td:eq(2)').find('#hdnLeadId').val();
    $.ajax({
        type: 'delete',
        url: '/LeadSource/DeleteLeadSource?LeadSrcId=' + leadId,
        processData: false,
        contentType: false,
        success: function (response) {
            var data = response;
            alert(data);
            if (data == 1) {
                alert('Lead deleted successfully');
            } else if (data == -1) {
                alert('Lead not deleted. Some error occured.');
            }
            location.reload();
        },
        error: function (msg) {
            alert('error occured');

        }
    });
});



