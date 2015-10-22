//rule 可以keyfram名
function findKeyframesRule(rule){
    var ss = document.styleSheets;
    for(var i = 0;i < ss.length;++i){
        for(var j = 0;j<ss[i].cssRules.length;++j){
            if(ss[i].cssRules[j].type == window.CSSRule.WEBKIT_KEYFRAMES_RULE && ss[i].cssRules[j].name == rule){
                return ss[i].cssRules[j];
            }
        }
    }
    return null;
}