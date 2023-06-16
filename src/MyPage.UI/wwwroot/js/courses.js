function openCourseModal(modalType) {
    document.documentElement.style.overflow = "hidden";
    document.getElementById("modal").style.display = "flex";
    document.getElementById(`${modalType}-course-modal`).style.display = "flex";

    setTimeout(() => {
        document.getElementById("modal").style.opacity = "1";
    }, 1)
}

function closeCourseModal() {
    document.documentElement.style.overflow = "auto";
    document.getElementById("modal").style.opacity = "0";

    setTimeout(() => {
        document.getElementById("modal").style.display = "none";
        document.getElementById("add-course-modal").style.display = "none";
        document.getElementById("update-course-modal").style.display = "none";
        document.getElementById("delete-course-modal").style.display = "none";
    }, 200)
}