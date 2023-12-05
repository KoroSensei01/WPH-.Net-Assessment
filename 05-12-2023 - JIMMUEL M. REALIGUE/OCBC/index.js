document.addEventListener("DOMContentLoaded", function () {
  // Find the link with the text 'WEBSITE'
  var websiteLink = document.getElementById("websiteLink");

  // Add a click event listener to the link
  websiteLink.addEventListener("click", function (event) {
    event.preventDefault(); // Prevent the default action of following the link

    // Get the title of the current document and display it in an alert
    var title = document.title;
    alert("The title of the current page is: " + title);
  });
});

document.addEventListener("DOMContentLoaded", function () {
  var image = document.getElementById("movingImage");
  image.style.left = "0"; // Move the image to the right inside the container
});
