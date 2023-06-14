function menuSwitch() {
    if (window.matchMedia("(min-width: 768px)").matches) {
        document.getElementById("menu-items").style.display = "flex";
        document.getElementById("menu-button-mobile").style.display = "none";

        document.getElementById("menu-items").style.flexDirection = "row";
        document.getElementById("menu-items").style.alignItems = "center";
        document.getElementById("menu-items").style.justifyContent = "center";
    } else {
        document.getElementById("menu-items").style.display = "none";
        document.getElementById("menu-button-mobile").style.display = "block";
    }
}

function handleMobileMenu() {
    let menuIsOpen = document.getElementById("menu-mobile").style.opacity === "1";
    if (menuIsOpen) {
        document.getElementById("menu-mobile").style.opacity = "0";
        document.getElementById("menu-mobile").style.transition = "opacity .3s linear";

        if (document.body.scrollTop > 20) {
            document.getElementById("menu-container").style.borderBottom = "2px solid rgba(255, 255, 255, 0.1)"
        }

        setTimeout(() => {
            document.getElementById("menu-mobile").style.display = "none"
        }, 200);
    } else {
        document.getElementById("menu-mobile").style.display = "flex"

        setTimeout(() => {
            document.getElementById("menu-container").style.borderBottom = "2px solid rgba(255, 255, 255, 0.0)"

            document.getElementById("menu-mobile").style.opacity = "1";
            document.getElementById("menu-mobile").style.transition = "opacity .3s linear";
        }, 1);
    }
}

function scrollFunction() {
    let menuIsOpen = document.getElementById("menu-mobile").style.opacity === "1";

    if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
        document.getElementById("menu-container").style.padding = "0 20px"
        document.getElementById("my-photo").style.width = "0"
        document.getElementById("my-photo").style.marginRight = "5px"

        if (!menuIsOpen) {
            document.getElementById("menu-container").style.borderBottom = "1px solid rgba(210, 213, 255, 0.3)"
        }

        document.getElementById("menu-container").style.transition = "border-bottom .3s linear, padding .3s linear";
        document.getElementById("my-photo").style.transition = "width .3s linear, margin .3s linear";
    } else {
        document.getElementById("my-photo").style.width = "5rem";
        document.getElementById("my-photo").style.marginRight = "20px";
        document.getElementById("my-photo").style.transition = "width .3s linear, margin .3s linear";
        document.getElementById("menu-container").style.padding = "20px";
        document.getElementById("menu-container").style.borderBottom = "2px solid rgba(255, 255, 255, 0)";
        document.getElementById("menu-container").style.transition = "border-bottom .3s linear, padding .3s linear";
    }
}

function copyEmail(email) {
    navigator.clipboard.writeText(email);
    document.getElementById("email").src = "/img/copy-checked.svg"
}

menuSwitch();
window.onscroll = () => scrollFunction();
window.addEventListener("resize", () => menuSwitch())