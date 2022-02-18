function navbarToggle() {
    var burger = document.getElementById("navbar");
    if (burger.className === "flex-container") {
      burger.className += " responsive";
    } else {
      burger.className = "flex-container";
    }
  }