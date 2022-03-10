// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const toggleButton = document.getElementById("burger-button");
const navbarLinks = document.getElementById("links");

toggleButton.AddEventListener('click', () => {
    navbarLinks.classList.toggle('active');
})