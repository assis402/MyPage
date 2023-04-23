function showAbout() {
    document.getElementById("presentation").style.opacity = "0";
    document.getElementById("presentation").style.cursor = "default";

    setTimeout(() => {
        document.getElementById("presentation").style.display = "none";
        document.getElementById("about-body-container").style.display = "block";
    }, 300)

    document.getElementById("about-body-container").style.opacity = "1";
}