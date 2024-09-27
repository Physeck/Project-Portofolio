fetch('header.html')
            .then(response => response.text())
            .then(data => {
                document.getElementById('header').innerHTML = data;
            })
            .catch(error => {
                console.log('Error:', error);
            });

    
function validateForm() {
    let email = document.getElementById("email").value;
    let username = document.getElementById("name").value;
    let checkin = document.getElementById("CID").value;
    let checkout = document.getElementById("COD").value;
    let roomType = document.getElementById("roomtype").value;
    let showAlert = false;
  
    if (!(email.includes("@") && email.includes("."))) {
        alert("Email must contain '@' and '.'");
        showAlert = true;
    }
  
    if (username.length < 6) {
      alert("Name must be at least 6 characters");
      showAlert = true;
     } 
  
    let convertedCID = new Date(checkin);
    let today = new Date();
    today.setHours(0, 0, 0, 0);
    if (convertedCID < today) {
        alert("Check-in date cannot be in the past");
        showAlert = true;
    }
  
    let convertedCOD = new Date(checkout);
    if (convertedCOD <= convertedCID) {
     alert("Check-out date must be greater than check-in date");
        showAlert = true;
    }
    if (roomType === "") {
    alert("Please select a room type");
    showAlert = true;
  }
  
    if (!showAlert) {
        alert("Book success!");
        document.getElementById("email").value = "";
        document.getElementById("name").value = "";
        document.getElementById("CID").value = "";
        document.getElementById("COD").value = "";
        document.getElementById("roomtype").selectedIndex = 0;
        window.location.href = "../../pages/home/home.html";

  }
}
