1.保留两位小数（不足两位不补0，如92.8转换后还是92.8）
<script>
var num=22.127456;
alert( Math.round(num*100)/100);
</script>

2.保留两位小数(不足两位，则补上0，会先将浮点数据四舍五入)
changeTwoDecimal(3.1415926)返回3.14 changeTwoDecimal(3.1)返回3.10

unction changeTwoDecimal_f(x) {
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        alert('function:changeTwoDecimal->parameter error');
        return false;
    }
    var f_x = Math.round(x * 100) / 100;
    var s_x = f_x.toString();
    var pos_decimal = s_x.indexOf('.');
    if (pos_decimal < 0) {
        pos_decimal = s_x.length;
        s_x += '.';
    }
    while (s_x.length <= pos_decimal + 2) {
        s_x += '0';
    }
    return s_x;
}