const navSlide = () => {
    const burger = document.querySelector('.burger');
    const nav = document.querySelector('.nav-links');
    const navLinks = document.querySelectorAll('.nav-links li');

    burger.addEventListener('click', () => {
        nav.classList.toggle('nav-active');

        navLinks.forEach((link, index) => {
            if (link.style.animation) {
                link.style.animation = '';
            } else {
                link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 + 0.3}s`;
            }
        });

        burger.classList.toggle('toggle');


    });
    /* Previous CSS code remains unchanged */

    /* Additional styling for the button */


    function updateProfile() {
        // Add functionality to update the user's profile here
        // For example, you could open a form to allow the user to edit their details
        // or make an API call to update the user's information.
        console.log('Update button clicked!');
    }

    function toggleNav() {
        var navLinks = document.getElementById("navLinks");
        var burger = document.querySelector('.burger');
        navLinks.classList.toggle('nav-active');
        burger.classList.toggle('toggle');
    }

};

navSlide();





