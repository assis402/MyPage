function animateAbout() {
    let element = document.getElementById("about-skills")

    if (element != undefined) {
        let position = element.getBoundingClientRect();
        if (window.pageYOffset > position.top || document.body.scrollTop > position.top) {
            let elements = document.getElementsByClassName("skill-bar");

            for (let i = 0; i < elements.length; i++) {
                elements[i].className = 'skill-bar skill-bar-animation';
            }
        }
    }
}