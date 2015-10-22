//获取指定范围内随机数
function getRandomNum(Min, Max) {
    var Range = Max - Min;
    var Rand = Math.random();
    return (Min + Math.floor(Rand * Range));
}