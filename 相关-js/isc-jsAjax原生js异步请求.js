///
//补充说明:
//与 POST 相比，GET 更简单也更快，并且在大部分情况下都能用。
//然而，在以下情况中，请使用 POST 请求：
// 1.无法使用缓存文件（更新服务器上的文件或数据库）
// 2.向服务器发送大量数据（POST 没有数据量限制）
// 3.发送包含未知字符的用户输入时，POST 比 GET 更稳定也更可靠
//作者:火骑士空空 author:huoqishi
///

$.get = Get;
$.post = Post;

var xhr;//XMLHttpRequest对象
//创建异步对象XMLHttpRequest，var xhr:CreateXmlHttp()
function CreateXmlHttp() {
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        return new XMLHttpRequest();
    }
    else {
        return  new ActiveXObject("Microsoft.XMLHTTP"); //ie 5,6
    }
}

//Get请求,url:请求地址,param:请求参数,callbackFunc:请求后的回调函数
function Get(url,param,callbackFunc) {
    //0、创建异步对象XMLHttpRequest
    xhr= CreateXmlHttp();
    //1、设置请求方式、目标、是否异步
    //1.1 Get方式
    xhr.open("GET", url+"?"+param, true);
    //1.2.1设置HTTP的输出内容类型为：application/x-www-form-urlencoded
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //1.2.2设置浏览器不使用缓存，服务器不从缓存中找，重新执行代码，而且服务器返回给浏览器的时候，告诉浏览器也不要保存缓存。
    xhr.setRequestHeader("If-Modified-Since", "0");

    //2、设置回调函数
    xhr.onreadystatechange = callbackFunc;  //callbackFunc是方法名

    //3、发送请求
    xhr.send(null); //GET方式
}

//Post请求，url:请求地址,param:请求参数(可以是Json格式),callbackFunc:请求后的回调函数
function Post(url, param, callbackFunc) {
    //0、创建异步对象XMLHttpRequest
    xhr = CreateXmlHttp();
    //1、设置请求方式、目标、是否异步
    //1.2 Post方式,如果是Post方式，还需要其他一些设置
    xhr.open("POST", url, true);
    //1.2.1设置HTTP的输出内容类型为：application/x-www-form-urlencoded
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //1.2.2设置浏览器不使用缓存，服务器不从缓存中找，重新执行代码，而且服务器返回给浏览器的时候，告诉浏览器也不要保存缓存。
    xhr.setRequestHeader("If-Modified-Since", "0");
    //2、设置回调函数
    xhr.onreadystatechange = function () {
        callbackFunc(xhr);
    };  //callbackFunc是方法名,此处用法类似于C#中的委托
    //3、发送请求
    xhr.send(param); //POST方式
}

function incallbackFun() {
    callbackFunc()
}

//回调函数--事例
function callFunc() {
    if (xhr.readyState == 0) {
        //alert("请求未初始化.........");
    }
    if (xhr.readyState == 1) {
        //alert("正在加载连接对象......");
    }
    if (xhr.readyState == 2) {
        //alert("连接对象加载完毕。");
    }
    if (xhr.readyState == 3) {
        //alert("数据获取中......");
    }
    if (xhr.readyState == 4) {
        if (xhr.status == 200) {
            var result = xhr.responseText; //获得服务器返回的字符串
            var obj = JSON.parse(result);//将Json字符转为Json对象,所有属性必需用双引号
            alert(resutl);
        }
    }
}

//有时间进一步封装Get,Post方法

