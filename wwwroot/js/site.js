// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
        if (screen.width <= 767) {
            function botaoDoMenu() {
                    var menu = document.getElementById("menu_header");
                    if (menu.style.display === "flex") {
                        //esconder o menu
                        menu.style.display = "none"
                    } else {
                        //mostrar o menu
                        menu.style.display = "flex"
                    }
                }
                function botaoDoMenuFechar() {
                    var menu = document.getElementById("menu_header");
                    if (menu.style.display === "flex") {
                        //esconder o menu
                        menu.style.display = "none"
                    }
                }
            } else 
        window.onresize = () => {
            if (screen.width > 767) {
                var menu = document.getElementById("menu_header");
                menu.style.display = "flex";
            } else{
                menu.style.display = "none";
            }
        }