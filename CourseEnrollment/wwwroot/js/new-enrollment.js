$(document).ready(function () {
    $(".select2").select2({
        placeholder: "Select Students",
        allowClear: true
    });
});

let isEnrolled = false; // Flag to track if enrolled students exist

function CheckIfEnrolled() {
    let stdIds = $("#SelectedStudentsIds").val();
    let crsId = $("#selectedCrsId").val();
    let warningSpan = $("span[data-valmsg-for='SelectedStudentsIds']");
    let submitButton = $("button[type='submit']");

    // Clear previous messages
    warningSpan.text("");
    isEnrolled = false; // Reset the flag

    if (!crsId) {
        return;
    }

    $.ajax({
        url: "/Enrollments/CheckIfEnrolled",
        type: "get",
        traditional: true,
        data: { selectedStudents: stdIds, crsId: crsId },
        success: function (result) {
            if (result.status == -1) {
                let enrolledNames = result.stds.map(s => s.fullName).join(", ");
                warningSpan.text("Already enrolled: " + enrolledNames).addClass("text-warning");
                isEnrolled = true; // Set flag to prevent submission
            }

            // Disable submit button if students are already enrolled
            submitButton.prop("disabled", isEnrolled);
        },
        error: function () {
            alert("Error loading students.");
        }
    });
}

// Prevent form submission if students are already enrolled
$("form").on("submit", function (e) {
    if (isEnrolled) {
        e.preventDefault(); // Stop form submission
        alert("Some students are already enrolled! Please remove them before proceeding.");
    }
});


function GetSlots() {
    let crsId = $("#selectedCrsId").val();

    if (!crsId) {
        return;
    }

    $("#slots").html("");
    //deselect students
    $("#SelectedStudentsIds").val([]).trigger("change"); 

    $.ajax({    
        url: "/Enrollments/GetSlots",
        type: "get",
        data: { crsId: crsId },
        success: function (result) {
            console.log(result);
            $("#slots").html(result.availableSlots);
            if (result.availableSlots <= 0) {
                $("#slots").css("color", "red");
            }
            else {
                $("#slots").css("color", "green");
            }
        },
        error: function () {
            alert("Error loading students.");
        }
    });
}