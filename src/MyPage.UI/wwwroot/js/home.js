function showAbout() {
    document.getElementById("presentation").style.opacity = "0";
    document.getElementById("presentation").style.cursor = "default";

    setTimeout(() => {
        document.getElementById("about-external-container").style.height = "auto";
        document.getElementById("presentation").style.display = "none";
        document.getElementById("about-body-container").style.display = "block";
    }, 200)

    document.getElementById("about-body-container").style.opacity = "1";
}