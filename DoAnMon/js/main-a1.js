$(function () {
	var idhientai = "";	
	$('div.ndcauhoi:first').show();
    $(".clickcauhoi").click(function () {
    	$(this).addClass('active').siblings().removeClass('active');
        $('.ndcauhoi').hide();
        $('#' + $(this).data('id')).show();		
		idhientai = $(this).data('id');
    });
	$(".cautruoc").click(function () {		
    	$(this).addClass('active').siblings().removeClass('active');
        $('.ndcauhoi').hide();		
		var i = 0;
		if (idhientai == ""){
			i = 1;
		}
		else{
			i = parseInt(idhientai.slice(4));
		}
		var a = i - 1;
		if (a == 0){
			a = 25;
		}		
		idhientai = "data" + a;
		var idtruoc = "#data" + a;
        $(idtruoc).show();
    });
	$(".causau").click(function () {		
    	$(this).addClass('active').siblings().removeClass('active');
        $('.ndcauhoi').hide();		
		var i = 0;
		if (idhientai == ""){	
			i = 1;
		}
		else{
			var i = parseInt(idhientai.slice(4));
		}
		var a = i + 1;
		if (a == 26){
			a = 1;
		}		
		idhientai = "data" + a;
		var idsau = "#data" + a;
        $(idsau).show();
    });
    $("#nopbai").click(function () {
                return confirm("Bạn chắc chắn muốn nộp bài?");
            });
    $(window).bind('scroll', function () {
    var menu = $('.menu');
    var thoigian = $('.thoigian');
    if ($(window).scrollTop() >= (menu.offset().top)) {
        menu.addClass('fixed');
    } else {
        menu.removeClass('fixed');
    }
});

});