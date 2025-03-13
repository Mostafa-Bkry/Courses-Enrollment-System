
document.addEventListener("DOMContentLoaded", function () {
    let deleteButtons = document.querySelectorAll(".delete-btn");
    let confirmDeleteBtn = document.getElementById("confirmDeleteBtn");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function () {
            let courseId = this.getAttribute("data-crsId");
            let studentId = this.getAttribute("data-stdId");
            let deleteUrl = `/Enrollments/Delete?crsId=${courseId}&stdId=${studentId}`;
            console.log(deleteUrl);
            confirmDeleteBtn.setAttribute("href", deleteUrl);
        });
    });
});