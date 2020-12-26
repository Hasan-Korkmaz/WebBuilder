const menu = document.querySelector('#mobile-menu');
const menuLinks = document.querySelector('.menu-container-mobile');
console.log(menu);
menu.addEventListener('click', function () {
    menu.classList.toggle('is-active');
    menuLinks.classList.toggle('active');
});


function footerDisplayColumnItems(element) {
    //console.log("Trigger click Function")
    //console.log("TÄ±klanan Elemenet:");
    //console.log(element);
    var sibling = element.nextElementSibling;
    //console.log(sibling);

    var c = element.children[1].children[0];

    if (sibling.style.display == "flex") {
        sibling.style.display = "none";
        c.className = "fas fa-plus";
    }
    else {
        sibling.style.display = "flex";
        c.className = "fas fa-minus";
        //sibling.style.transition = "height 3s";
    }
}


function dropdownLanguageOnClick(element) {
    console.log(element);
    sibling = element.nextElementSibling;
    icon = element.children[0];

    if (sibling.style.display == "block") {
        sibling.style.display = "none";
        icon.className = "fas fa-plus";
    }
    else {
        sibling.style.display = "block";
        icon.className = "fas fa-minus";
    }
    console.log(sibling);
    console.log(icon);
}



