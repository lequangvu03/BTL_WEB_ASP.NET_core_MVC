document.addEventListener('DOMContentLoaded', function () {
    const menuToggle = document.getElementById('menu-toggle');
    const navbarNav = document.querySelector('.navbar-nav');

    menuToggle.addEventListener('click', function () {
        navbarNav.classList.toggle('show');
    });
});