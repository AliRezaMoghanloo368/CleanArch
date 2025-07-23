function inputPassword() {
    var x = document.getElementById("input-password");
    var img = document.getElementById("img-password");
    if (x.type === "password") {
        x.type = "text";
        img.src = "/images/icons/eye-off.svg";  // تصویر چشم بسته یا حالت مخفی
    } else {
        x.type = "password";
        img.src = "/images/icons/eye.svg";      // تصویر چشم باز یا حالت نمایش
    }
}

function inputRepassword() {
    var x = document.getElementById("input-repassword");
    var img = document.getElementById("img-repassword");
    if (x.type === "password") {
        x.type = "text";
        img.src = "/images/icons/eye-off.svg"; 
    } else {
        x.type = "password";
        img.src = "/images/icons/eye.svg"; 
    }
}
