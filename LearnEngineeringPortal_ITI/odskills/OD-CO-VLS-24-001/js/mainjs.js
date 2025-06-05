  <script type="text/javascript">
	  

 
     

	  jQuery(document).ready(function($) {
	
	$('.unit1').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	$('.unit2').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	$('.unit3').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	$('.unit4').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	$('.unit5').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	$('.unit6').owlCarousel({items:3, loop:false, margin:10, lazyLoad:true, merge:true, callbacks:false, nav:false, video:true, themeClass:'owl-theme1', dots : false,  autoplay:false, autoplayTimeout:1800, nav:true, responsive:{320:{items:1},480:{items:2},678:{items:4},960:{items:3}}
	});
	

});

	
         $(document).ready(function() {
                 //Horizontal Tab
                 $('#parentHorizontalTab').easyResponsiveTabs({
                     type: 'default', //Types: default, vertical, accordion
                     width: 'auto', //auto or any width like 600px
                     fit: true, // 100% fit in a container
                     tabidentify: 'hor_1', // The tab groups identifier
                     activate: function(event) { // Callback function if tab is switched
                         var $tab = $(this);
                         var $info = $('#nested-tabInfo');
                         var $name = $('span', $info);
                         $name.text($tab.text());
                         $info.show();
                     }
                 });
         		
         		
         		
         		});
         		
         		
         
         $("#dHub li").click(function(){
         	$("#popupDiv").slideDown(500);
         });
         $("#popBtnClose").click(function(){
         	$("#popupDiv").slideUp(500);
         });
         $("#1").click(function(){
         	$("#div1").show();
         	$("#div2").hide();
         	$("#div3").hide();
         	$("#div4").hide();
         	
         });
         $("#2").click(function(){
         	$("#div2").show();
         	$("#div1").hide();
         	$("#div3").hide();
         	$("#div4").hide();
         	
         });
         $("#3").click(function(){
         	$("#div3").show();
         	$("#div1").hide();
         	$("#div2").hide();
         	$("#div4").hide();
         	
         });
         $("#4").click(function(){
         	$("#div4").show();
         	$("#div1").hide();
         	$("#div2").hide();
         	$("#div3").hide();
         	
         });
         function learnBtnOpen(){
         
         
         if ($("#learnMenuDiv").css("display") == "none") { 
                $('#learnMenuDiv').css({"display":"block"});
            }
            else {
                $('#learnMenuDiv').css({"display":"none"});
           }
           
         }
         
         /*$(document).ready(function(){
           $("#learnBtnOpen").click(function(){
            // $("#learnMenuDiv1").delay(1200).show();
            // $("#learnMenuDiv2").delay(800).show();
             //$("#learnMenuDiv3").delay(400).show();
             $("#learnMenuDiv").show();
            
           });
         });*/
         
          /*$("#learnBtnOpen").click(function(){
         		$("#learnMenuDiv").show("slide", { direction: "right" }, 1000);
         		$("#learnBtnOpen").hide();
             });
         	$("#learnBtnClose").click(function(){
         		$("#learnMenuDiv").hide("slide", { direction: "right" }, 1000);
         		$("#learnBtnOpen").show();
             });*/
             
         
            $(document).ready(function(){
           
         
         	var head = $("#mainHead").outerHeight(true);
         	var foot = $("#footerHeight").outerHeight(true);
         	var heightcontent = head + foot;
         	var holmonitor = window.innerHeight;
         	var holecontent = holmonitor - heightcontent;
         	
         	document.getElementById("contentHeight").style.height = holecontent + "px";
			 var topHeight = $("#popTopHead").outerHeight(true);
					var tabHeight = $("#popTopTab").outerHeight(true);
					var totalHeight = topHeight;
					var totalContHeight = holmonitor - totalHeight -2;
					document.getElementById("tabContHeight").style.height = totalContHeight + "px";
         	
         	
			
             if (window.matchMedia("(max-width: 767px)").matches) {
                 
         		 document.getElementById("preImg").src = "../../../images/pre.png";
                 document.getElementById("nexImg").src = "../../../images/nex.png";
                 document.getElementById("tabContHeight").style.height = auto;
             } else {
                 document.getElementById("preImg").src = "../../../images/previous.png";
                 document.getElementById("nexImg").src = "../../../images/next.png";
				
             }
			 
                 
         });
		 
         
         
         
         	   
         function openNav() {
         
         	var element = document.getElementById("mySidenav");
         	element.classList.add("sidenavw-width");
         	var element = document.getElementById("mySidenavDiv");
         	element.classList.add("left-container-res");
         	
             //document.getElementById("mySidenav").style.width = "400px";
         	
         }
         
         function closeNav() {
         var element = document.getElementById("mySidenav");
         	element.classList.remove("sidenavw-width");
         	var element = document.getElementById("mySidenavDiv");
         	element.classList.remove("left-container-res");
             //document.getElementById("mySidenav").style.width = "0";
         }
          
         
         document.getElementById("dateAndTime").innerHTML = formatAMPM();
         
         function formatAMPM() {
         var d = new Date(),
             minutes = d.getMinutes().toString().length == 1 ? '0'+d.getMinutes() : d.getMinutes(),
             hours = d.getHours().toString().length == 1 ? '0'+d.getHours() : d.getHours(),
             ampm = d.getHours() >= 12 ? 'pm' : 'am',
             months = ['1','2','3','4','5','6','7','8','9','10','11','12'],
             days = ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
         return hours+':'+minutes+' '+ampm+' '+d.getDate() +'-'+months[d.getMonth()]+'-'+d.getFullYear();
         }
         	
      </script>