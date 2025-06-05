


			
/***** Scroll Top ****/		
	
	//Check to see if the window is top if not then display button
	$(window).scroll(function(){
		if ($(this).scrollTop() > 100) {
			$('.scrollToTop').fadeIn();
		} else {
			$('.scrollToTop').fadeOut();
		}
	});
	
	//Click event to scroll to top
	$('.scrollToTop').click(function(){
		$('html, body').animate({scrollTop : 0},800);
		return false;
	});
/***** scroll Top end *****/

	
	//social toggle
	$(document).ready(function(){
		$(".social-toggle").click(function(){			
			$(".social-bar").animate({
				width: "toggle"
			});
			 $('.social-toggle').find('.fa').toggleClass('fa-angle-right fa-angle-left');
		});		
		
	});
	//
	
/**** maginific popup ***/
	$(document).ready(function(){
	$('.video-popup').magnificPopup({
		  delegate: 'a', // child items selector, by clicking on it popup will open
		  type: 'iframe'
		  // other options
	});
	});
/*******/
	
var revapi;
	/*Buynow page*/
	$(function (argument) {
		
		function toggleChevron(e) {
			$(e.target)
			.prev('.panel-heading')
			.find("i.indicator")
			.toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
		}
		$('.accordion').on('hidden.bs.collapse', toggleChevron);
		$('.accordion').on('shown.bs.collapse', toggleChevron);
		$(".viewtoggle").click(function(e) {
			e.preventDefault();
			$('#products').find('.product-content').toggleClass('list-view');
			$(this).toggleClass('active')

			$(this).find('span').text(function(i, text){
			  });                                
		});

		$('#filterXs').click(function(e) {
			e.preventDefault();
			$('.filter').removeClass('hidden-xs');
		});

		$('#filterClose').click(function(e) {
			e.preventDefault();
			$('.filter').addClass('hidden-xs');
		});

		/* Price: Syllabus Accordion Panel-Heading Active */
		$('.price-syllabus .accordion').on('show', function (e) {
			 $(e.target).prev('.accordion-heading').find('.accordion-toggle').addClass('green-active');
		});

		$('.price-syllabus .accordion').on('hide', function (e) {
			$(this).find('.accordion-toggle').not($(e.target)).removeClass('green-active');
		});
	});

	function filterHeight() {
		var height = $(window).height();
		var filterTitlebarXs = $('.filter-titlebar-xs').height();
		var filterSearchXs = $('.filter-block-xs .search').height();
		var filterContentHeight = height - filterTitlebarXs - filterSearchXs - 100;
		$('.filter .dropdown-menu').height(filterContentHeight);
	}

	$(document).ready(function() {
		filterHeight();
		$(window).bind('resize', filterHeight);
	});

	$(document).ready(function(){
		$('#univ-all').on('click',function(){
			if(this.checked){
				$('.univ-checkbox').each(function(){
					this.checked = true;
				});
			}else{
				 $('.univ-checkbox').each(function(){
					this.checked = false;
				});
			}
		});
		
		$('.univ-checkbox').on('click',function(){
			if($('.univ-checkbox:checked').length == $('.univ-checkbox').length){
				$('#univ-all').prop('checked',true);
			}else{
				$('#univ-all').prop('checked',false);
			}
		});
	});

	$(document).ready(function(){
		$('#regu-all').on('click',function(){
			if(this.checked){
				$('.regu-checkbox').each(function(){
					this.checked = true;
				});
			}else{
				 $('.regu-checkbox').each(function(){
					this.checked = false;
				});
			}
		});
		
		$('.regu-checkbox').on('click',function(){
			if($('.regu-checkbox:checked').length == $('.regu-checkbox').length){
				$('#regu-all').prop('checked',true);
			}else{
				$('#regu-all').prop('checked',false);
			}
		});
	});

	$(document).ready(function(){
		$('#branch-all').on('click',function(){
			if(this.checked){
				$('.branch-checkbox').each(function(){
					this.checked = true;
				});
			}else{
				 $('.branch-checkbox').each(function(){
					this.checked = false;
				});
			}
		});
		
		$('.branch-checkbox').on('click',function(){
			if($('.branch-checkbox:checked').length == $('.branch-checkbox').length){
				$('#branch-all').prop('checked',true);
			}else{
				$('#branch-all').prop('checked',false);
			}
		});
	});
	
	/* Load Function*/
	$(function(){
		$("#navcontent").load("theme_v2/includes_v2/header.html");
		$("#footer-menu").load("theme_v2/includes_v2/footer-top.html"); 
		$("#feedback").load("theme_v2/includes_v2/feedback.html");
		$("#callback").load("theme_v2/includes_v2/callback.html");
		$("#livechat").load("theme_v2/includes_v2/livechat.html");
		$("#footer-bottom").load("theme_v2/includes_v2/footer-bottom.html");
		$("#product-header").load("theme_v2/includes_v2/product-header.html");
	});
	
	
	/*Incremental Counter*/
	(function($){
		$.fn.incrementalCounter = function(options){
			//default options
			var defauts = {
					"digits": 4
				},
				pad = function(n, width, z) {
					z = z || '0';
					n = n + '';
					return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
				},
				start = function(element){

					var current_value = parseInt($(element).data('current_value')),
						end_value = $(element).data('end_value'),
						current_speed = 20;

					if (end_value - current_value < 5){
						current_speed = 200;
						current_value += 1;
					} else if(end_value - current_value < 15){
						current_speed = 50;
						current_value += 1
					} else if(end_value - current_value < 50){
						current_speed = 25;
						current_value += 3
					} else{
						current_speed = 25;
						current_value += parseInt((end_value - current_value)/24)
					}

					$(element).data({
						current_value:current_value
					});

					if(current_speed){
						setTimeout(function(){
							display($(element),current_value);
						},current_speed);
					}else{
						display($(element),current_value);
					}
				},
				display = function(element,value){
					var padedNumber = pad(value, element.data('digits')),
						exp = padedNumber.split(""),
						end_value = $(element).data('end_value'),
						nums = $(element).find('.num');
					$(exp).each(function(i,e){
						$(nums[i]).text(exp[i]);
					});

					if(end_value != value){
						start(element);
					}
				},
			//merge options
				options = $.extend(defauts, options);

			this.each(function(index,element){

				var default_digits = options.digits ,
					digits =  element.getAttribute('data-digits') ?  element.getAttribute('data-digits') : default_digits ,
					end_value = parseInt( element.getAttribute('data-value'));

				digits = digits === 'auto' || digits < String(end_value).length ? String(end_value).length : digits;

				//get value
				$(element).data({
					current_value : 0,
					end_value : end_value,
					digits : digits,
					current_speed : 0
				});

				//add number container
				for(var i=0 ; i < digits ; i++){
					$(element).append('<div class="num">0</div>');
				}

				start($(element));

			});
			return this;
		};
	})(jQuery);
	
	jQuery(document).ready(function() {
		var screenh = window.screen.height;
		var screenw = window.screen.width


		var screenheight = screenh   ;
		//alert(screenheight);

		revapi = jQuery('.tp-banner').revolution(
							{
							delay:9000,
							startwidth:1170,
							startheight:screenheight, 
							forceFullWidth:"on",
							minFullScreenHeight:"320", 
							videoJsPath:"../videojs/", 
							spinner:"spinner5",
							lazyType: "smart",
							navigationType:"none",				// bullet, thumb, none
							navigationArrows:"none", 
							fullScreenOffsetContainer: ""
						});

		$('#tab_selector').on('change', function (e) {
            $('.form-tabs li a').eq($(this).val()).tab('show');
        });

	});	//ready	
			 

	$(document).ready(function() {

		$(function($) {
			"use strict";
			$('.animated').appear(function() {
				var elem = $(this);
				var animation = elem.data('animation');
				if ( !elem.hasClass('visible') ) {
					var animationDelay = elem.data('animation-delay');
					if ( animationDelay ) {

						setTimeout(function(){
							elem.addClass( animation + " visible" );
						}, animationDelay);

					} else {
						elem.addClass( animation + " visible" );
					}
				}
			});
		});
	}); 
 
	 
	$(window).load(function() {
		 	
				$("body").imagesLoaded(function(){
					$(".loader-item").delay(700).fadeOut();
					$("#pageloader").delay(800).fadeOut("slow");
				});
			});

		jQuery(document).ready(function(){
			if( $('.cd-stretchy-nav').length > 0 ) {
				var stretchyNavs = $('.cd-stretchy-nav');
				
				stretchyNavs.each(function(){
					var stretchyNav = $(this),
						stretchyNavTrigger = stretchyNav.find('.cd-nav-trigger');
					
					stretchyNavTrigger.on('click', function(event){
						event.preventDefault();
						stretchyNav.toggleClass('nav-is-visible');
					});
				});

				$(document).on('click', function(event){
					( !$(event.target).is('.cd-nav-trigger') && !$(event.target).is('.cd-nav-trigger span') ) && stretchyNavs.removeClass('nav-is-visible');
				});
			}
	});
		//Feedback
	$('.cd-btn').on('click', function(event){
				event.preventDefault();
				$('.cd-panel').addClass('is-visible');
			});
			//clode the lateral panel
			$('.cd-panel').on('click', function(event){
				if( $(event.target).is('.cd-panel') || $(event.target).is('.cd-panel-close') ) { 
					$('.cd-panel').removeClass('is-visible');
					event.preventDefault();
				}
			});
			
			//Call Back
			$('.cd-btn-cb').on('click', function(event){
				event.preventDefault();
				$('.cd-panel-cb').addClass('is-visible');
			});
			//clode the lateral panel
			$('.cd-panel-cb').on('click', function(event){
				if( $(event.target).is('.cd-panel-cb') || $(event.target).is('.cd-panel-cb-close') ) { 
					$('.cd-panel-cb').removeClass('is-visible');
					event.preventDefault();
				}
			});
			
			//Live Chat
			$('.cd-btn-lc').on('click', function(event){
				event.preventDefault();
				$('.cd-panel-lc').addClass('is-visible');
			});
			//clode the lateral panel
			$('.cd-panel-lc').on('click', function(event){
				if( $(event.target).is('.cd-panel-lc') || $(event.target).is('.cd-panel-lc-close') ) { 
					$('.cd-panel-lc').removeClass('is-visible');
					event.preventDefault();
				}
	});
	$(window).load(function() {

	  var bar = new ProgressBar.Line(progbar, {
	  strokeWidth: 4,
	  easing: 'easeInOut',
	  duration: 1400,
	  color: '#908a78',
	  trailColor: '#eee',
	  trailWidth: 1,
	  svgStyle: {width: '100%', height: '100%'},
	  text: {
	    style: {
	      // Text color.
	      // Default: same as stroke color (options.color)
	      color: '#FFF',
	      position: 'relative',
	      right: '0',
	      top: '0px',
	      padding: 0,
	      margin: 0,
	      transform: null
	    },
	    autoStyleContainer: false
	  },
	  from: {color: '#908a78'},
	  to: {color: '#908a78'},
	  step: (state, bar) => {
	    bar.setText(Math.round(bar.value() * 100) + ' %');
	  }
	});

	bar.animate(1.0);  // Number from 0.0 to 1.0
})
 
$(function() {
        "use strict";
        var owlSectionOneItem = $("#owlSectionOneItem");
        owlSectionOneItem.owlCarousel({
            autoPlay: 5000,
            items : 1,  
            itemsDesktop : [1000,1],  
            itemsDesktopSmall : [900,1],  
            itemsTablet: [600,1],  
            itemsMobile : false
        });
        
        var owlSectionTwoItem = $("#owlSectionTwoItem, #owlSectionTwoItem2, #owlSectionTwoItem3, #owlSectionTwoItem4, #owlSectionTwoItem5");
        owlSectionTwoItem.owlCarousel({
            autoPlay: 5000,
            items : 2,  
            itemsDesktop : [1000,2],  
            itemsDesktopSmall : [900,2],  
            itemsTablet: [600,1],  
            itemsMobile : false
        });
        
        var owlSectionThreeItem = $("#owlSectionThreeItem");
        owlSectionThreeItem.owlCarousel({
            autoPlay: 5000,
            items : 3,  
            itemsDesktop : [1000,3],  
            itemsDesktopSmall : [900,3],  
            itemsTablet: [600,1],  
            itemsMobile : false
        });
        
        var owlSectionFourItem = $("#owlSectionFourItem");
        owlSectionFourItem.owlCarousel({
            autoPlay: 5000,
            items : 4,  
            itemsDesktop : [1000,4],  
            itemsDesktopSmall : [900,2],  
            itemsTablet: [600,2],  
            itemsMobile : false
        });
        
        var owlSectionFiveItem = $("#owlSectionFiveItem");
        owlSectionFiveItem.owlCarousel({
            autoPlay: 5000,
            items : 5,  
            itemsDesktop : [1000,5],  
            itemsDesktopSmall : [900,3],  
            itemsTablet: [600,3],  
            itemsMobile : false
        });
        
        var owlSectionSixItem = $("#owlSectionSixItem");
        owlSectionSixItem.owlCarousel({
            autoPlay: 5000,
            items : 6,  
            itemsDesktop : [1000,6],  
            itemsDesktopSmall : [900,3],  
            itemsTablet: [600,3],  
            itemsMobile : false
        });
        

    });    
    
    /* --------------------------------------------------------
	 OWL CAROUSEL FOR SHOP
	-----------------------------------------------------------  */          
    $(function() {
        "use strict";
        var owlShop = $("#owlShop, #owlShop2, #owlShop3, #owlShop4");

        owlShop.owlCarousel({
            slideSpeed : 1000,
            autoPlay : true,
            pagination: false,
            items : 4, 
        });

        $(".shop-control-next").on('click', function(){
            owlShop.trigger('owl.next');
        })
        $(".shop-control-prev").on('click', function(){
            owlShop.trigger('owl.prev');
        });

    });
	$(function() {
        "use strict";
        var owlShop = $("#owlShop, #owlShop2, #owlShop3, #owlShop4");

        owlShop.owlCarousel({
            slideSpeed : 1000,
            autoPlay : true,
            pagination: false,
            items : 4, 
        });

        $(".shop-control-next").on('click', function(){
            owlShop.trigger('owl.next');
        })
        $(".shop-control-prev").on('click', function(){
            owlShop.trigger('owl.prev');
        });

    });
	$(document).ready(function() {
		$('.social-icons').on('click', function (e) {
			e.preventDefault();
			var expanSocialIcons = $('.expand-social-icons');

			if(expanSocialIcons.hasClass('showed')) {
				expanSocialIcons.removeClass('showed');
				expanSocialIcons.css('display', 'none');
			} else {
				expanSocialIcons.addClass('showed');
				expanSocialIcons.css('display', 'block');
			}
		});

	});
	$(document).ready(function() {
		$( "#list-ourcourses" ).click(function() {

			//alert("List Show"); 
			
			$('#topcourse-list').css({'display':'block'});
			$('#topcourse-list').show("slow");
			$('#topcourse-grid').hide("slow");
			$('#topcourse-grid').css({'display':'none'});

		});
		$( "#grid-ourcourses" ).click(function() {

			//alert("grid Show"); 
			
			$('#topcourse-grid').css({'display':'block'});
			$('#topcourse-grid').show("slow");
			$('#topcourse-list').hide("slow");
			$('#topcourse-list').css({'display':'none'});
			 
		});
	});
	$(".carousel").swipe({

		swipe: function(event, direction, distance, duration, fingerCount, fingerData) {

			if (direction == 'left') $(this).carousel('next');
			if (direction == 'right') $(this).carousel('prev');

		},
		allowPageScroll:"vertical"

	});
    
	$(window).scroll(function() {
		var scroll = $(window).scrollTop();
		
		if (scroll >= 300) {
			$(".course").removeClass("nav-course");
			$(".course").addClass("fadeInDown");
		}
		else{
			$(".course").addClass("nav-course");
			$(".course").removeClass("fadeInDown");
		}
	});
	
	var footerMenuPos = $('#footer-menu').offset().top;
	if($('#pricing').length){
		var contentPos = $('#pricing').offset().top + $('#pricing').height() + 50;
	}
	$(window).scroll(function() {
		var footerTop = $("#footer-menu").height();
		var footerBottom = $("footer").height();
		var footerTotal = footerTop + footerBottom;
		var priceVideo = $(".pricing-video").height();
		var windowHeight = $(window).height();
		var priceTop = windowHeight - footerTotal;
		var topPos = priceTop - 135;
		var windowPos = $(window).scrollTop();
		
		if($(window).scrollTop() + $(window).height() > $(document).height() - footerTotal) { 
			$('.buy-subjects').css('bottom', footerTotal+20);
			$(".visitor-count").addClass("fadeInUp");
			$('.visitor-count').css('display', 'block');
		}
		else{
			$('.buy-subjects').css('bottom', '0');
		}
		
		var pricevideoPos = $('.pricing-video').offset().top + $(".pricing-video").height();
		var fixedPos = windowHeight - (priceVideo + footerTotal + 20);
		/*Price Video*/
		
		if(pricevideoPos >= contentPos ) { 
			$('.pricing-video').css({'top' : fixedPos});			
		}
		else{			
			$('.pricing-video').css({'top' : 135});			
		}
	});
	function loginToRegister(){
		try
		{
			$(".mobile-register").addClass("visible-xs");
			$(".mobile-register").removeClass("hidden-xs");
			$(".mobile-login").addClass("hidden-xs");
			$(".mobile-login").removeClass("visible-xs");
		}
		catch(e){
			console.log(e)
		}
	}
	function registerToLogin(){
		try
		{
			$(".mobile-login").addClass("visible-xs");
			$(".mobile-login").removeClass("hidden-xs");
			$(".mobile-register").addClass("hidden-xs");
			$(".mobile-register").removeClass("visible-xs");
		}
		catch(e){
			console.log(e)
		}
	}

	
	$(function (argument) {
	
	function toggleChevron(e) {
		$(e.target)
		.prev('.panel-heading')
		.find("i.indicator")
		.toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
	}
	$('.accordion').on('hidden.bs.collapse', toggleChevron);
	$('.accordion').on('shown.bs.collapse', toggleChevron);

	

	/* Price: Syllabus Accordion Panel-Heading Active */
	$('.price-syllabus .accordion').on('show', function (e) {
         $(e.target).prev('.accordion-heading').find('.accordion-toggle').addClass('green-active');
    });

    $('.price-syllabus .accordion').on('hide', function (e) {
        $(this).find('.accordion-toggle').not($(e.target)).removeClass('green-active');
    });
	$( window ).scroll(function() {
	  	//$( "span" ).css( "display", "inline" ).fadeOut( "slow" );
	  	//console.log($('body').height());
	});
})

$('#syllabus').on('hidden.bs.collapse', function (e) {
   $(this).find('.panel-heading').not($(e.target)).removeClass('accordion-opened');
   $(this).find('.panel-title').not($(e.target)).removeClass('green-active');
});
$('#syllabus').on('shown.bs.collapse',  function (e) {
	$(e.target).prev('.panel-heading').addClass('accordion-opened');
	$(e.target).prev('.panel-heading').find('.panel-title').addClass('green-active');
});

function toggleSeeMore() {
	if(document.getElementById("textarea").style.display == 'none') {
		document.getElementById("textarea").style.display = 'block';
		document.getElementById("seeMore").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea").style.display = 'none';
		document.getElementById("seeMore").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore1() {
	if(document.getElementById("textarea1").style.display == 'none') {
		document.getElementById("textarea1").style.display = 'block';
		document.getElementById("seeMore1").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea1").style.display = 'none';
		document.getElementById("seeMore1").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore2() {
	if(document.getElementById("textarea2").style.display == 'none') {
		document.getElementById("textarea2").style.display = 'block';
		document.getElementById("seeMore2").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea2").style.display = 'none';
		document.getElementById("seeMore2").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore3() {
	if(document.getElementById("textarea3").style.display == 'none') {
		document.getElementById("textarea3").style.display = 'block';
		document.getElementById("seeMore3").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea3").style.display = 'none';
		document.getElementById("seeMore3").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore4() {
	if(document.getElementById("textarea4").style.display == 'none') {
		document.getElementById("textarea4").style.display = 'block';
		document.getElementById("seeMore4").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea4").style.display = 'none';
		document.getElementById("seeMore4").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore5() {
	if(document.getElementById("textarea5").style.display == 'none') {
		document.getElementById("textarea5").style.display = 'block';
		document.getElementById("seeMore5").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea5").style.display = 'none';
		document.getElementById("seeMore5").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore6() {
	if(document.getElementById("textarea6").style.display == 'none') {
		document.getElementById("textarea6").style.display = 'block';
		document.getElementById("seeMore6").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea6").style.display = 'none';
		document.getElementById("seeMore6").innerHTML = 'Read more...';        
	}
}
function toggleSeeMore7() {
	if(document.getElementById("textarea7").style.display == 'none') {
		document.getElementById("textarea7").style.display = 'block';
		document.getElementById("seeMore7").innerHTML = '<i class="fa fa-angle-double-up"></i> Less ';
	}
	else {
		document.getElementById("textarea7").style.display = 'none';
		document.getElementById("seeMore7").innerHTML = 'Read more...';        
	}
}

function toggleShowmore1() {
	if(document.getElementById("more-videos1").style.display == 'none') {
		document.getElementById("more-videos1").style.display = 'block';
		document.getElementById("showmore1").innerHTML = 'Show Less <i class="fa fa-angle-double-up"></i> ';
	}
	else {
		document.getElementById("more-videos1").style.display = 'none';
		document.getElementById("showmore1").innerHTML = 'Show more...<i class="fa fa-angle-double-down"></i> ';        
	}
}
function toggleShowmore2() {
	if(document.getElementById("more-videos2").style.display == 'none') {
		document.getElementById("more-videos2").style.display = 'block';
		document.getElementById("showmore2").innerHTML = 'Show Less <i class="fa fa-angle-double-up"></i> ';
	}
	else {
		document.getElementById("more-videos2").style.display = 'none';
		document.getElementById("showmore2").innerHTML = 'Show more...<i class="fa fa-angle-double-down"></i> ';        
	}
}


