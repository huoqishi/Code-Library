// 备份jquery || zepto的ajax方法    
    var _ajax = $.ajax;
    
    // 重写ajax方法，先判断登录在执行success函数   
    $.ajax = function (_opt) {
        var success = _opt.success;
        _opt.success = function (data, status, xhr) {
            var header = xhr.getResponseHeader("session-expired");
            if (header == 'expired') {
                alert('请先登陆,再继续操作！');
            }
            success(data,status,xhr);
        }
        _ajax(_opt);
    };