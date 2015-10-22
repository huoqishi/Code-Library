var processor = {  
    timeoutId: null,  
 
    performProcessing: function(){  
            // 要执行的代码  
    },  
 
    process: function(){  
        clearTimeout(this.timeoutId);  
        this.timeoutId  = setTimeout(function(){  
            processor.performProcessing();  
        }, 100);  
    }  
};  
 
//调用  
processor.process();  
performProcessing 是真正要调用的函数，而程序的入口在 process，每次进入 process，真正要调用的函数
 performProcessing 都会被延迟 100 毫秒执行，如果在此期间，process 再次被调用，则会重置前一次的计时器，
重新开始计时，这样保证了 performProcessing 中的代码至少要间隔 100 毫秒才会被执行一次，原理非常的简单

方法2：
        n=0;
        function resizehandler(){
            console.log(new Date().getTime());
            console.log(++n);
        }

        function throttle(method,context){
            clearTimeout(method.tId);
            method.tId=setTimeout(function(){
                method.call(context);
            },500);
        }

        window.onresize=function(){
            throttle(resizehandler,window);
        };

方法3：
function throttle(method,delay){
            var timer=null;
            return function(){
                var context=this, args=arguments;
                clearTimeout(timer);
                timer=setTimeout(function(){
                    method.apply(context,args);
                },delay);
            }
        }

        因为返回的是函数句柄，注册事件时不用包装函数

方法。。。。