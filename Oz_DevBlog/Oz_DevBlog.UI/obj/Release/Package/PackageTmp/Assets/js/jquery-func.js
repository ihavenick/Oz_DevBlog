$(document).ready(function(){
	
	'use strict';

	//=================================== Sticky nav ===================================//
	$("nav").sticky({topSpacing:0});


 	//=================================== Nav Responsive ===================================//
    $('#menu').tinyNav({
       active: 'selected'
    });

    //=================================== IMAGE HOVER  =================================//

	$('.img-preview').each(function() {

	    $(this).hover(
	    function() {
	        $(this).stop().animate({ opacity: 1.0 }, 300);
	    },
	    function() {
	    	$(this).stop().animate({ opacity: 0 }, 300);
	     })
	});

	//=================================== Subtmit Form  =================================//

	$('#form').submit(function(event) {  
	  event.preventDefault();  
	  var url = $(this).attr('action');  
	  var datos = $(this).serialize();  
	  $.get(url, datos, function(resultado) {  
	    $('#result').html(resultado);  
	  });  
	});  

    //=================================== Accordion  =================================//
	
	$('.accordion-container').hide(); 
	$('.accordion-trigger:first').addClass('active').next().show();
	$('.accordion-trigger').click(function(){
		if( $(this).next().is(':hidden') ) { 
			$('.accordion-trigger').removeClass('active').next().slideUp();
			$(this).toggleClass('active').next().slideDown();
		}
		return false;
	});

	 //================================== Scroll Efects ================================//

	 $(window).scroll(function() {

	    $('.title_area h1, .item_info').each(function(){
	    	var imagePos = $(this).offset().top;
	        
	        var topOfWindow = $(window).scrollTop();
	        	if (imagePos < topOfWindow+400) {
	                 $(this).addClass("animated fadeInUp");
	             }
	     }); 

	     $('.info_area .title_section').each(function(){
	    	var imagePos = $(this).offset().top;
	        
	        var topOfWindow = $(window).scrollTop();
	        	if (imagePos < topOfWindow+400) {
	                 $(this).addClass("animated fadeInLeft");
	             }
	     });     	

	     $('.meter span').each(function(){
	    	var imagePos = $(this).offset().top;
	        
	        var topOfWindow = $(window).scrollTop();
	        	if (imagePos < topOfWindow+400) {
	                 $(this).addClass("stretchRight");
	             }
	     });     	                    

	  });

	//=================================== Scrollbar  ===================================//

	$(".img-preview").mCustomScrollbar({
        scrollButtons:{
            enable:true
        }
    });

	//=================================== Ligbox  ===================================//
	
	jQuery("a[class*=html_portfolio]").fancybox({		
        'autoScale'     	: true,
        'overlayOpacity'	:	0.7,
		'overlayColor'		:	'#000000',	
		'easingIn'      	: 'easeOutBack',
		'easingOut'     	: 'easeInBack',
		'speedIn' 			: '700',
		'centerOnScroll'	: true,
		'type'				: 'iframe'
	});

	jQuery("a[class*=html_blog]").fancybox({
		'width'				: '65',
		'height'			: '110',		
        'autoScale'     	: true,
        'overlayOpacity'	:	0.7,
		'overlayColor'		:	'#000000',	
		'easingIn'      	: 'easeOutBack',
		'easingOut'     	: 'easeInBack',
		'speedIn' 			: '700',
		'centerOnScroll'	: true,
		'type'				: 'iframe'
	});

	    jQuery("a[class*=fancybox]").fancybox({
		'overlayOpacity'	:	0.7,
		'overlayColor'		:	'#000000',
		'transitionIn'		: 'elastic',
		'transitionOut'		: 'elastic',
		'easingIn'      	: 'easeOutBack',
		'easingOut'     	: 'easeInBack',
		'speedIn' 			: '700',
		'centerOnScroll'	: true
	});
	
	jQuery("a[class*='video_lightbox']").click(function(){
		var et_video_href = jQuery(this).attr('href'),
			et_video_link;

		et_vimeo = et_video_href.match(/vimeo.com\/(.*)/i);
		if ( et_vimeo != null )	et_video_link = 'http://player.vimeo.com/video/' + et_vimeo[1];
		else {
			et_youtube = et_video_href.match(/watch\?v=([^&]*)/i);
			if ( et_youtube != null ) et_video_link = 'http://youtube.com/embed/' + et_youtube[1];
		}
		
		jQuery.fancybox({
			'overlayOpacity'	:	0.7,
			'overlayColor'		:	'#000000',
			'autoScale'		: true,
			'transitionIn'	: 'elastic',
			'transitionOut'	: 'elastic',
			'easingIn'      : 'easeOutBack',
			'easingOut'     : 'easeInBack',
			'type'			: 'iframe',
			'centerOnScroll'	: true,
			'speedIn' 			: '700',
			'href'			: et_video_link
		});
		return false;
	});

	//=================================== Tooltips =====================================//

	if( $.fn.tooltip() ) {
		$('[class="tooltip_hover"]').tooltip();
	}
        
});



