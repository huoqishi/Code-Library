//#region 获取偏移位置(参数不区分大小写) 需要之前设置过translate3D + int getTrans() 
///return {x:x,y:y,z:z}
$.fn.getTrans = getTrans;
function getTrans() {
    var $obj = $(this);
    var trans = $obj.css('transform') || $obj.css('-webkit-transform') || $obj.css('-moz-transform') || $obj.css('-o-transform') || $obj.css('-ms-transform', str);
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
    var tmpZ=z>0?parseFloat(temp[z]):0;
    return { x: parseFloat(temp[x]), y: parseFloat(temp[y]), z: tmpZ };
}
///#endregion

$('..').offset().top;//元素相对浏览器左上角的位置，包括偏移