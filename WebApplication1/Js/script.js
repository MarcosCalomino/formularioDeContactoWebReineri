var checkboxes = document.querySelectorAll('.check-image-container input[type="checkbox"]');

// Itera sobre todos los checkboxes y asigna el manejador de eventos
checkboxes.forEach(function (checkbox) {
    checkbox.addEventListener('click', function () {
        // Desmarca todos los checkboxes
        checkboxes.forEach(function (otherCheckbox) {
            otherCheckbox.checked = false;
        });

        // Marca solo el checkbox actual
        checkbox.checked = true;
    });
});