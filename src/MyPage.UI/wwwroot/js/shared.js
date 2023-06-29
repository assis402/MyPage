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

        if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
            document.getElementById("menu-container").style.borderBottom = "1px solid rgba(255, 255, 255, 0.15)"
        }
        else {
            document.getElementById("menu-background").style.opacity = "0";
        }

        setTimeout(() => {
            document.getElementById("menu-mobile").style.display = "none"
        }, 300);
    } else {
        document.getElementById("menu-mobile").style.display = "flex"

        setTimeout(() => {
            document.getElementById("menu-container").style.borderBottom = "0px solid rgba(255, 255, 255, 0.0)"

            document.getElementById("menu-mobile").style.opacity = "1";
            document.getElementById("menu-mobile").style.transition = "opacity .3s linear";
            document.getElementById("menu-background").style.opacity = "1";
        }, 1);
    }
}

function scrollFunction() {
    let menuIsOpen = document.getElementById("menu-mobile").style.opacity === "1";

    if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
        document.getElementById("menu-container").style.padding = "0 20px"
        document.getElementById("menu-background").style.opacity = "1";
        document.getElementById("my-photo").style.width = "0"
        document.getElementById("my-photo").style.marginRight = "5px"

        if (!menuIsOpen) {
            document.getElementById("menu-container").style.borderBottom = "1px solid rgba(210, 213, 255, 0.15)"
        }

        document.getElementById("my-photo").style.transition = "width .3s linear, margin .3s linear";
    } else {
        document.getElementById("my-photo").style.width = "5rem";
        document.getElementById("my-photo").style.marginRight = "20px";
        document.getElementById("my-photo").style.transition = "width .3s linear, margin .3s linear";
        document.getElementById("menu-container").style.padding = "20px";
        document.getElementById("menu-container").style.borderBottom = "0px solid rgba(255, 255, 255, 0)";

        if (!menuIsOpen) {
            document.getElementById("menu-background").style.opacity = "0";
        }
    }
}

function copyEmail(email) {
    navigator.clipboard.writeText(email);
    document.getElementById("email").src = "/img/copy-checked.svg"
}

menuSwitch();

window.onscroll = () => {
    animateAbout();
    scrollFunction();
}

window.addEventListener("resize", () => menuSwitch())

if (history.scrollRestoration) {
    history.scrollRestoration = 'manual';
} else {
    window.onbeforeunload = function () {
        window.scrollTo(0, 0);
    }
}