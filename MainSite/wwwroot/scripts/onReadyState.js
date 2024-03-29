﻿//Установка высоты блока , как у родительского
function setHeightChildrenBlock(el) {
    var element = document.getElementById(el);
    var parentElement = element.parentElement.offsetHeight;
    if (parentElement == 0) parentElement = window.innerHeight - 120;

    element.style.minHeight = parentElement + "px";
}

function aligmentWidthChildsBirthdayBlock() {
    var el = document.querySelector('.card_birthday-content');
    var items = document.querySelectorAll('.card_birthday-content > div');
    if (items.length > 3) {
        el.style.justifyContent = "space-between";
    }
    else {
        if (items.length != 0) {
            for (var item in items) {
                item.style.paddingRight = "33px";
            }
        }
    }
}

function eventClickMobileIconMenu() {
    //выбираем нужные элементы
    var el = document.getElementById('openMenu');
    el.onClick = function (e) {
        var secondMenuHtml = document.querySelector('.secondMenu-infoUser').innerHTML + document.querySelector('.secondMenu-settingsUser').innerHTML;
        var secondMenuBlock = document.querySelector('.secondMenuBlock');
        secondMenuBlock.innerHTML = secondMenuHtml;
        var menuBLock = document.getElementById('menuBlock');
        menuBLock.classList.toggle('active');
     };
}

/*document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var dropdownOptions = {
        inDuration: 500,
        outDuration: 425,
        constrain_width: true,
        coverTrigger: false,// Does not change width of dropdown to that of the activator
       // hover: true, // Activate on hover
        //gutter: (document.getElementsByClassName('dropdown-content')[0].width *3)/2.5 + 5, // Spacing from edge
        belowOrigin: false, // Displays dropdown below the button
        alignment: 'center' // Displays dropdown with edge aligned to the left of button
    };
    var instances = M.Dropdown.init(elems, dropdownOptions);
});*/

/*document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.collapsible.expandable');
    var instances = M.Collapsible.init(elems, {
        accordion: false
    });
});*/

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems);
});
  

eventClickMobileIconMenu();
aligmentWidthChildsBirthdayBlock()
setHeightChildrenBlock("mainBlock");