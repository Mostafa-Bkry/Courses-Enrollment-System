
//Getting students per selected course
function GetStudents() {
    let crsId = $("#crs").val();
    // console.log(crsId);
    $("#enrolled").html("");
    $.ajax(
        {
            url: "/Enrollments/GetEnrolled",
            data: { "crsId": crsId },
            success: function (result) {
                $("#enrolled").html(result);
            },
            error: function () {
                alert("Error loading students.");
            }
        }
    );
}

function GetCrsandStd(crsId, stdId) {
    let confirmDeleteBtn = document.getElementById("confirmDeleteBtn");

    let deleteUrl = `/Enrollments/Delete?crsId=${crsId}&stdId=${stdId}`;
    console.log(deleteUrl);
    confirmDeleteBtn.setAttribute("href", deleteUrl);
};