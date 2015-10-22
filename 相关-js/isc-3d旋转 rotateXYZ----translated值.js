基于zepto,基jquery;
$.fn.rotateX = rotateX;
$.fn.rotateY = rotateY;
$.fn.rotateZ = rotateZ;
function rotateX(val) {
    rotate('X', val, this);
}
function rotateY(val) {
    rotate('Y', val, this);
}
function rotateZ(val) {
    rotate('Z', val, this);
}

//private
function rotate(direction, val, this2) {
    var str = 'rotate' + direction;
    val = val + 'deg';
    str += '(' + val + ')';
    var $obj = $(this2);
    $obj.css('-webkit-transform', str);
    $obj.css('transform', str);
    $obj.css('-moz-transform', str);
    $obj.css('-o-transform', str);
    $obj.css('-ms-transform', str);
}
//translated  x,y,z//////////////////////////////////////
//#region 获取偏移位置(参数不区分大小写) 需要之前设置过translate3D + int getTrans() 
///return {x:x,y:y,z:z}
$.fn.getTrans = getTrans;
function getTrans() {
    var $obj = $(this);
    var trans = $obj.css('transform') || $obj.css('-webkit-transform') || $obj.css('-moz-transform') || $obj.css('-o-transform') || $obj.css('-ms-transform');
    if (trans=='none') {
        return { x: 0, y: 0, z: 0 };
    }
    var temp = trans.split(/\(|\)/)[1].split(/,/);
    var x = -1, y = -1, z = -1;
    if (trans.indexOf('matrix3d') != -1) {
        x = 12; y = 13; z = 14;
    } else if (trans.indexOf('matrix') != -1) {
        x = 4;
        y = 5;
    }
    else {
        x = 0, y = 1, z = 3;
    }
    var tmpZ = z > 0 ? parseFloat(temp[z]) : 0;
        var tmpX = temp[x], tmpY = temp[y];
        var win=$(window);
        var h = win.height();
        var w = win.width();
        tmpX=tmpX.indexOf('%') != -1 ? parseFloat(tmpX.substr(0, tmpX.length - 1))/100*w : parseFloat(tmpX);
        tmpY=tmpY.indexOf('%') != -1 ? parseFloat(tmpY.substr(0, tmpY.length - 1))/100*h : parseFloat(tmpY);
        return { x: tmpX, y: tmpY, z: tmpZ };
}
///设置 translated
//通过GPU渲染替换使用，left,top  _trans3d(obj,x,y,z), obj为zepto对象
$.fn.trans3d = trans3d;
function trans3d(x, y, z) {
    var $obj = $(this);
    //return $obj.css('top', y + 'px');
    ///
    var xa = x + "px";
    var ya = y + "px";
    var za = z + "px";
    if (xa.indexOf('%') != -1) { xa = x; }
    if (ya.indexOf('%') != -1) { ya = y; }
    var str = "translate3d(" + xa + "," + ya + ", " + za + ")";
    if (za=='undefined') {
        str = "translate3d(" + xa + "," + ya + ")";
    } if (ya=='undefined') {
        str = "translateX(" + xa+ ")";
    }
    $obj.css('-webkit-transform', str);
    $obj.css('transform', str);
    $obj.css('-moz-transform', str);
    $obj.css('-o-transform', str);
    $obj.css('-ms-transform', str);
    return $obj;
}

//设置css样式,使用prefixfree时使用，自动添加前缀
 $.fn.cssPrefix = cssPrefix;
    //设置css样式,使用prefixfree时使用，自动添加前缀
    function cssPrefix(arg, arg2) {
        var st = $(this)[0].style;
        if (arg2) {
            st[arg] = arg2;
        } else {
            for (var key in arg) {
                st[key] = arg[key];
            }
        }
    }