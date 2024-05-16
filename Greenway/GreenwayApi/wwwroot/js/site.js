eyeBtn.onclick = function () {
    let pswdLogin = document.getElementById("pswd");
    let buttonEye = document.getElementById("eyeBtn");

    if (pswdLogin.type === "password") {
        pswdLogin.setAttribute("type", "text");
        buttonEye.classList.add("hdPwdLgn");
    } else {
        pswdLogin.setAttribute("type", "password");
        buttonEye.classList.remove("hdPwdLgn");
    }
};