menuSwitch();

function menuSwitch() {
    let menuItems = document.getElementById("menu-items");
    let menuButtonMobile = document.getElementById("menu-button-mobile");
    let timelineArrow = document.getElementById('timeline-arrow');

    if (window.matchMedia("(min-width: 768px)").matches) {
        menuItems.style.display = "flex";
        menuButtonMobile.style.display = "none";

        menuItems.style.flexDirection = "row";
        menuItems.style.alignItems = "center";
        menuItems.style.justifyContent = "center";
    } else {
        menuItems.style.display = "none";
        menuButtonMobile.style.display = "block";
    }
}

function handleMobileMenu() {
    let menuBackground = document.getElementById("menu-background");
    let menuMobile = document.getElementById("menu-mobile");
    let menuIsOpen = menuMobile.style.opacity === "1";

    if (menuIsOpen) {
        menuMobile.style.opacity = "0";

        if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
            menuBackground.style.borderBottom = "1px solid rgba(255, 255, 255, 0.15)"
        }
        else {
            menuBackground.style.opacity = "0";
        }

        setTimeout(() => {
            menuMobile.style.display = "none"
        }, 200);
    } else {
        menuMobile.style.display = "flex"

        setTimeout(() => {
            menuMobile.style.opacity = "1";
            menuBackground.style.opacity = "1";
        }, 1);
    }
}

function scrollFunction() {
    let menuBackground = document.getElementById("menu-background");
    let menuContainer = document.getElementById("menu-container");
    let myPhoto = document.getElementById("my-photo");
    let menuIsOpen = document.getElementById("menu-mobile").style.opacity === "1";

    if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
        menuContainer.style.padding = "0 20px"
        menuBackground.style.opacity = "1";
        myPhoto.style.width = "0"
        myPhoto.style.marginRight = "5px"
        myPhoto.style.transition = "width .3s linear, margin .3s linear";

        if (!menuIsOpen) {
            menuBackground.style.borderBottom = "1px solid rgba(210, 213, 255, 0.15)"
        }
    } else {
        myPhoto.style.width = "5rem";
        myPhoto.style.marginRight = "20px";
        myPhoto.style.transition = "width .3s linear, margin .3s linear";
        menuContainer.style.padding = "20px";

        if (!menuIsOpen) {
            menuBackground.style.opacity = "0";
        }
    }
}

function copyEmail(email) {
    navigator.clipboard.writeText(email);
    document.getElementById("email").src = "/img/copy-checked.svg"
}

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

const checkbox = document.getElementById('checkbox');

checkbox.addEventListener('change', (event) => {
    if (checkbox.checked) {
        checkbox.value = 'true';
    } else {
        checkbox.value = 'false';
    }
})