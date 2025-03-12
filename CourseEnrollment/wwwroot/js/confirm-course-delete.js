document.addEventListener("DOMContentLoaded", function () {
    let deleteButtons = document.querySelectorAll(".delete-btn");
    let confirmDeleteBtn = document.getElementById("confirmDeleteBtn");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function () {
            let courseId = this.getAttribute("data-id");
            let deleteUrl = `/Courses/Delete/${courseId}`;
            confirmDeleteBtn.setAttribute("href", deleteUrl);
        });
    });
});