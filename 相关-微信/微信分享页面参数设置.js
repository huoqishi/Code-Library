var imgUrl = 'http://zf-lucywj.ishuchang.net:8082/img/title_pic.jpg';
var lineLink = 'http://zf-lucywj.ishuchang.net:8082';
var descContent = "韩版男士衬衫调查问卷。欢迎拍砖提建议，之后免费赠送精美衬衫一件。。     ---Lucy";
var shareTitle = '韩版男士衬衫问卷调查';
var appid = 'wxc9937e3a66af6dc8';

function shareFriend() {
    WeixinJSBridge.invoke('sendAppMessage', {
        "appid": appid,
        "img_url": imgUrl,
        "img_width": "640",
        "img_height": "640",
        "link": lineLink,
        "desc": descContent,
        "title": shareTitle
    }, function (res) {
        _report('send_msg', res.err_msg);
    })
}
function shareTimeline() {
    WeixinJSBridge.invoke('shareTimeline', {
        "img_url": imgUrl,
        "img_width": "640",
        "img_height": "640",
        "link": lineLink,
        "desc": descContent,
        "title": shareTitle
    }, function (res) {
        _report('timeline', res.err_msg);
    });
}
function shareWeibo() {
    WeixinJSBridge.invoke('shareWeibo', {
        "content": descContent,
        "url": lineLink,
    }, function (res) {
        _report('weibo', res.err_msg);
    });
}
// 当微信内置浏览器完成内部初始化后会触发WeixinJSBridgeReady事件。
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {

    // 发送给好友
    WeixinJSBridge.on('menu:share:appmessage', function (argv) {
        shareFriend();
    });

    // 分享到朋友圈
    WeixinJSBridge.on('menu:share:timeline', function (argv) {
        shareTimeline();
    });

    // 分享到微博
    WeixinJSBridge.on('menu:share:weibo', function (argv) {
        shareWeibo();
    });
}, false);