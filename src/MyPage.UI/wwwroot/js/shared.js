menuSwitch();

const Menu = document.querySelector('.menu-btn');

Menu.addEventListener('click', () => toggleMenu())

function toggleMenu() {
    Menu.classList.toggle('ativo');
}
function menuSwitch() {
    let menuItems = document.getElementById("menu-items");

    if (window.matchMedia("(min-width: 768px)").matches) {
        menuItems.style.display = "flex";

        menuItems.style.flexDirection = "row";
        menuItems.style.alignItems = "center";
        menuItems.style.justifyContent = "center";
    } else {
        menuItems.style.display = "none";
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
    let scrollUpButton = document.getElementById("scroll-up-button");

    if (window.pageYOffset > 20 || document.body.scrollTop > 20) {
        scrollUpButton.style.bottom = "20px";
        menuContainer.style.padding = "0 20px"
        menuBackground.style.opacity = "1";
        myPhoto.style.width = "0"
        myPhoto.style.height = "0"
        myPhoto.style.marginRight = "5px"
        myPhoto.style.transition = "height .3s ease-in-out, width .3s ease-in-out, margin .3s ease-in-out";

        if (!menuIsOpen) {
            menuBackground.style.borderBottom = "1px solid rgba(210, 213, 255, 0.15)"
        }
    } else {
        scrollUpButton.style.bottom = "-80px";
        scrollUpButton.style.border = "1px solid #53535a4f";
        myPhoto.style.width = "5rem";
        myPhoto.style.height = "5rem";
        myPhoto.style.marginRight = "20px";
        myPhoto.style.transition = "height .3s ease-in-out, width .3s ease-in-out, margin .3s ease-in-out";
        menuContainer.style.padding = "20px";

        if (!menuIsOpen) {
            menuBackground.style.opacity = "0";
        }
    }
}

function copyEmail(email) {
    navigator.clipboard.writeText(email);

    let copyPopup = document.getElementById("copy-popup");

    copyPopup.classList.remove("fade-animation");
    void copyPopup.offsetWidth;
    copyPopup.classList.add("fade-animation");
}

function scrollUp() {
    //if ('scrollRestoration' in history) {
    //    history.scrollRestoration = 'manual';
    //}
    //window.scrollTo(0, 0);
    ////window.pageYOffset = 0;
    //document.body.scrollTop = document.documentElement.scrollTop = 0;
    $("html, body").animate({ scrollTop: "0px" }, 300);

    let button = document.getElementById("scroll-up-button");
    button.classList.remove("zoom-animation");
    void button.offsetWidth;
    button.classList.add("zoom-animation");
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

if (checkbox != undefined) {
    checkbox.addEventListener('change', (event) => {
        if (checkbox.checked) {
            checkbox.value = 'true';
        } else {
            checkbox.value = 'false';
        }
    })
}

$(window).load(function () {
    $(".loader").fadeOut("slow");
});