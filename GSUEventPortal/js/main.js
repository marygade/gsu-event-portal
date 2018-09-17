var currentImage = 1;
setInterval(function () {
    console.log(currentImage + " before");
    $("#sliderImage").attr("src", "coverimages/" + currentImage + ".jpg");
    console.log(currentImage + " after");
    currentImage++;
    console.log(currentImage + " after i");
    if (currentImage > 10) {
        currentImage = 1;
    }
}, 2000);