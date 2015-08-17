function qqService(qq){
//    var qq_list = new Array('626770319', '1365799928');
//    //随机
//    var qq_i = Math.floor(Math.random()*qq_list.length);
    var element="<iframe style='display:none;' class='qq_iframe' src='tencent://message/?uin="+qq+"&Site=&menu=yes'></iframe>";
    $("body").append(element);
}