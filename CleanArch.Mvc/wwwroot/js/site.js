// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function inputPassword() {
    var x = document.getElementById("input-password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function inputRepassword() {
    var x = document.getElementById("input-repassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
