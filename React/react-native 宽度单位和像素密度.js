不支持 百分比，不需要单位{width:10}
单位其实是pt,不是px


通过PixelRatio获取实际大小
如：
图片大小为100*100px,实际设置应该如下：
var image = getImage({
   width: 200 * PixelRatio.get(),
   height: 100 * PixelRatio.get()
 });
 <Image source={image} style={{width: 200, height: 100}} />
