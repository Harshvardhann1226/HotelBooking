function Add() {
    var villa = {
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Price: $('#Price').val(),
        Sqft: $('#Sqft').val(),
        Occupency: $('#Occupency').val(),
        ImageUrl: $('#ImageUrl').val()
    };

    $("#loader").removeClass("d-none"); // show loader

    $.ajax({
        url: '/Villa/CreateVilla',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(villa),
        success: function (result) {
          
           
            if (result.Success) {
               
                $("#villaForm")[0].reset();
                window.location.href = "https://localhost:7100/Villa/VillaIndex";
              

            } else {
                alert("Something went wrong");
            }
        },
        error: function () {
            alert("Error while saving data");
        },
        complete: function () {
            $("#loader").addClass("d-none"); // hide loader
        }
    });
}

function openEditModal(id) {
    $.ajax({
        url: '/Villa/UpdateVilla',
        type: 'GET',
        data: { id: id },
        success: function (result) {
            if (result.Success) {
                $('#editId').val(result.data.Id);
                $('#editName').val(result.data.Name);
                $('#editDescription').val(result.data.Description);
                $('#editPrice').val(result.data.Price);
                $('#editSqft').val(result.data.Sqft);
                $('#editOccupency').val(result.data.Occupency);

                var modalEl = document.getElementById('editVillaModal');
                var editModal = new bootstrap.Modal(modalEl); // create instance
                editModal.show();
                
            } else {
                alert("Villa not found");
            }
        },
        error: function () {
            alert("Error loading villa data");
        }
    });
}
function deleteVilla(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Villa/DeleteVilla',
                type: 'DELETE',
                data: { id: id },
                success: function (response) {
                    if (response.Success) {
                        Swal.fire(
                            'Deleted!',
                            'Villa has been deleted.',
                            'success'
                        );
                        // Optionally, remove the row from table
                        //$('#villaRow_' + id).remove();
                        window.location.href = "https://localhost:7100/Villa/VillaIndex";
                    } else {
                        Swal.fire('Error!', 'Villa could not be deleted.', 'error');
                    }
                },
                error: function () {
                    Swal.fire('Error!', 'Something went wrong.', 'error');
                }
            });
        }
    });
}

