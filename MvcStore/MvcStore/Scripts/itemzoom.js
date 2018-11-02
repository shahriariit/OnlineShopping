$(document).ready(function () {
    var options = {
        zoomType: 'reverse',
        lens: true,
        preloadImages: true,
        alwaysOn: false,
        zoomWidth: 300,
        zoomHeight: 250,
        xOffset: 90,
        yOffset: 30,
        position: 'left'
        //...MORE OPTIONS  
    };
    $('a#MYCLASS').jqzoom(options);
});
