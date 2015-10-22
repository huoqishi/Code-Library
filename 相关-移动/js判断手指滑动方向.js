var startX = 0;
var startY = 0;
var $obj=$('.box');
$obj.on("touchstart", function(e) {
    e.preventDefault();
    startX = e.originalEvent.changedTouches[0].pageX,
    startY = e.originalEvent.changedTouches[0].pageY;
});

$obj.on("touchmove", function(e) {
    e.preventDefault();
    //moveEndX = e.originalEvent.changedTouches[0].pageX;
    //moveEndY = e.originalEvent.changedTouches[0].pageY;
    var touch = e.targetTouches[0]
        var moveEndX = touch.screenX;
        var moveEndY = touch.screenY;
    X = moveEndX - startX;
    Y = moveEndY - startY;
 
    if ( X > 0 ) {
        alert("left to right");
    }
    else if ( X < 0 ) {
        alert("right to left");
    }
    else if ( Y > 0) {
        alert("top to bottom");
    }
    else if ( Y < 0 ) {
        alert("bottom to top");
    }
    else{
        alert("just touch");
    }
});