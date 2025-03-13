document.addEventListener("DOMContentLoaded", function () {
    let deleteButtons = document.querySelectorAll(".delete-btn");
    let confirmDeleteBtn = document.getElementById("confirmDeleteBtn");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function () {
            let studentId = this.getAttribute("data-id");
            let deleteUrl = `/Students/Delete/${studentId}`;
            confirmDeleteBtn.setAttribute("href", deleteUrl);
        });
    });
});