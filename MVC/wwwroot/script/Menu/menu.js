document.addEventListener('DOMContentLoaded', function () {
    var showButtons = document.querySelectorAll('.show');

    showButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var extras = this.nextElementSibling;
            if (extras.style.display === 'none' || extras.style.display === '') {
                extras.style.display = 'block';
            } else {
                extras.style.display = 'none';
            }
        });
    });
});