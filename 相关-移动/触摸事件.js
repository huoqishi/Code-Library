四个事件：
--touchstart
--touchmove
--touchend
--touchcancel 

--和鼠标点击事件一样，有相似的顺序：
--touchstart → mouseover → mousemove → mousedown → mouseup → click完成

--touchstart类似mousedown
//示例
var ddd=document.getElementById('Id');
ddd.ontouchstart=function(e){
   var touch=e.touches[0];//touches是触摸点的数组  
   //获取触摸点坐标
   var x=touch.clientX;
   var y=touch.clientY;
}
//touchmove类似mousemove
ddd.ontouchmove=function(e){	//可为touchstart、touchmove事件加上preventDefault从而阻止触摸时浏览器的缩放、滚动条滚动等
	e.preventDefault();
};

e.touches--屏幕上所有的手指数组
e.targetTouches--Dom元素上所有手指数组
e.changedTouches--涉及当前事件手指的列表
例：，dom上有5个手指,有4个在移动，那么dom的移动事件中，只有4个手指,即e.changeTouches.length=4;

e.changedTouches[i].identifier 唯一标识当前手指
e.changedTouches[i].screenX,creenY --相对屏幕左上角，不是浏览器;
e.changedTouches[i].clientX,clientY--相对整个页面左上角位置;
e.changedTouches[i].pageX,pageY    --相对页面左角，再加个页面滚动的距离，即相对于页面滚动条的初始位置。