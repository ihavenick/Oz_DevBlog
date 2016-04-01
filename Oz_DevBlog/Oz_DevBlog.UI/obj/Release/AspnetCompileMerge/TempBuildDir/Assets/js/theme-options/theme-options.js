	$('#theme-options ul.backgrounds li').click(function(){
		$bgSrc = $(this).css('background-image');
		if ($(this).attr('class') == 'bgnone')
			$bgSrc = "none";

		$('body').css('background-image',$bgSrc);
		$.cookie('background', $bgSrc);
		$.cookie('backgroundclass', $(this).attr('class').replace(' active',''));
		$(this).addClass('active').siblings().removeClass('active');
	});


	$('#theme-options .title').click(function(){

		if ($('#theme-options').css('left') == "-180px")
		{
			$left = "0px";
			$.cookie('displayoptions', "0");
		} else {
			$left = "-180px";
			$.cookie('displayoptions', "1");
		}

		$('#theme-options').animate({
			left: $left
		},{
			duration: 500,
			easing: "easeInOutExpo"
		});


	});

	$(function(){
		$('#theme-options').fadeIn();
		$bgSrc = $.cookie('background');
		$('body').css('background-image',$bgSrc);

		if ($.cookie('displayoptions') == "1")
		{
			$('#theme-options').css('left','-180px');
		} else if ($.cookie('displayoptions') == "0") {
			$('#theme-options').css('left','0');
		} else {
			$('#theme-options').delay(800).animate({
				left: "-180px"
			},{
				duration: 500,
				easing: "easeInOutExpo"
			});

			$.cookie('displayoptions', "1");
		}

		$('#theme-options ul.backgrounds').find('li.' + $.cookie('backgroundclass')).addClass('active');

	});

//=================================== Skins Changer ====================================//

google.setOnLoadCallback(function(){

	'use strict';

    // Color changer

    $(".black").click(function(){
        $(".skin").attr("href", "css/skins/black/black.css");       
        return false;
    });

    $(".red").click(function(){
        $(".skin").attr("href", "css/skins/red/red.css");       
        return false;
    });
    
    $(".blue").click(function(){
        $(".skin").attr("href", "css/skins/blue/blue.css");      
        return false;
    });
    
    $(".derki").click(function(){
        $(".skin").attr("href", "css/skins/derki/derki.css");       
        return false;
    });

    $(".green").click(function(){
        $(".skin").attr("href", "css/skins/green/green.css");       
        return false;
    });

    $(".orange").click(function(){
        $(".skin").attr("href", "css/skins/orange/orange.css");       
        return false;
    });
    
});
