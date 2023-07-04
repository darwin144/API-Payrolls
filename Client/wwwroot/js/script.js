'use strict';

/**
 * navbar variables
 */

const navToggleBtn = document.querySelector("[data-nav-toggle-btn]");
const header = document.querySelector("[data-header]");

navToggleBtn.addEventListener("click", function () {
    header.classList.toggle("active");
});

/*// script.js
fetch('https://dummyjson.com/users')
    .then(response => response.json())
    .then(data => {
        document.getElementById('profile-views').textContent = data.age;
        document.getElementById('followers').textContent = data.birthdate;
        document.getElementById('following').textContent = data.height;
        document.getElementById('saved-post').textContent = data.weight;
    })
    .catch(error => console.log(error));*/
