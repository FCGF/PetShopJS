(function($) {
    "use strict";

    // jQuery for page scrolling feature - requires jQuery Easing plugin
    $('body').on('click', '.page-scroll a', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - 85 )
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });

    $("body").scrollspy({target: ".navbar-collapse", offset:200});

    // Gallery Slider
    $('#gal-slider').flexslider({
        animation: "fade",
        slideshow: false,
        directionNav: false,
        controlsContainer: ".gal-wrap",
        controlNav: true,
        manualControls: ".gal-nav li"
    });

    // Twitterfeed
    $('#tweetcool').tweecool({
        profile_image: false,
        username: 'envato',
        limit: 1
    });

    // SLIDER REVOLUTION
    jQuery('.tp-banner').show().revolution({
        dottedOverlay: "none",
        delay: 16000,
        startwidth: 1170,
        startheight: 700,
        hideThumbs: 200,

        thumbWidth: 100,
        thumbHeight: 50,
        thumbAmount: 5,

        navigationType: "bullet",
        navigationArrows: "solo",
        navigationStyle: "preview1",

        touchenabled: "on",
        onHoverStop: "on",

        swipe_velocity: 0.7,
        swipe_min_touches: 1,
        swipe_max_touches: 1,
        drag_block_vertical: false,

        parallax: "mouse",
        parallaxBgFreeze: "on",
        parallaxLevels: [7, 4, 3, 2, 5, 4, 3, 2, 1, 0],

        keyboardNavigation: "off",

        navigationHAlign: "center",
        navigationVAlign: "bottom",
        navigationHOffset: 0,
        navigationVOffset: 20,

        soloArrowLeftHalign: "left",
        soloArrowLeftValign: "center",
        soloArrowLeftHOffset: 20,
        soloArrowLeftVOffset: 0,

        soloArrowRightHalign: "right",
        soloArrowRightValign: "center",
        soloArrowRightHOffset: 20,
        soloArrowRightVOffset: 0,

        shadow: 0,
        fullWidth: "on",
        fullScreen: "off",

        spinner: "spinner4",

        stopLoop: "off",
        stopAfterLoops: -1,
        stopAtSlide: -1,

        shuffle: "off",

        autoHeight: "off",
        forceFullWidth: "off",



        hideThumbsOnMobile: "off",
        hideNavDelayOnMobile: 1500,
        hideBulletsOnMobile: "off",
        hideArrowsOnMobile: "off",
        hideThumbsUnderResolution: 0,

        hideSliderAtLimit: 0,
        hideCaptionAtLimit: 0,
        hideAllCaptionAtLilmit: 0,
        startWithSlide: 0,
        videoJsPath: "rs-plugin/videojs/",
        fullScreenOffsetContainer: ""
    });



    // SLIDER REVOLUTION
    jQuery('.tp-banner1').show().revolution({
        dottedOverlay: "none",
        delay: 16000,
        startwidth: 1170,
        startheight: 550,
        hideThumbs: 200,

        thumbWidth: 100,
        thumbHeight: 50,
        thumbAmount: 5,

        navigationType: "bullet",
        navigationArrows: "solo",
        navigationStyle: "preview5",

        touchenabled: "on",
        onHoverStop: "on",

        swipe_velocity: 0.7,
        swipe_min_touches: 1,
        swipe_max_touches: 1,
        drag_block_vertical: false,

        parallax: "mouse",
        parallaxBgFreeze: "on",
        parallaxLevels: [7, 4, 3, 2, 5, 4, 3, 2, 1, 0],

        keyboardNavigation: "off",

        navigationHAlign: "center",
        navigationVAlign: "bottom",
        navigationHOffset: 0,
        navigationVOffset: 20,

        soloArrowLeftHalign: "left",
        soloArrowLeftValign: "center",
        soloArrowLeftHOffset: 20,
        soloArrowLeftVOffset: 0,

        soloArrowRightHalign: "right",
        soloArrowRightValign: "center",
        soloArrowRightHOffset: 20,
        soloArrowRightVOffset: 0,

        shadow: 0,
        fullWidth: "on",
        fullScreen: "off",

        spinner: "spinner4",

        stopLoop: "off",
        stopAfterLoops: -1,
        stopAtSlide: -1,

        shuffle: "off",

        autoHeight: "off",
        forceFullWidth: "off",



        hideThumbsOnMobile: "off",
        hideNavDelayOnMobile: 1500,
        hideBulletsOnMobile: "off",
        hideArrowsOnMobile: "off",
        hideThumbsUnderResolution: 0,

        hideSliderAtLimit: 0,
        hideCaptionAtLimit: 0,
        hideAllCaptionAtLilmit: 0,
        startWithSlide: 0,
        videoJsPath: "rs-plugin/videojs/",
        fullScreenOffsetContainer: ""
    });

    // SLIDER REVOLUTION
    jQuery('.tp-banner-full').show().revolution({
        dottedOverlay: "none",
        delay: 16000,
        startwidth: 1170,
        startheight: 700,
        hideThumbs: 200,

        thumbWidth: 100,
        thumbHeight: 50,
        thumbAmount: 5,

        navigationType: "bullet",
        navigationArrows: "solo",
        navigationStyle: "preview5",

        touchenabled: "on",
        onHoverStop: "on",

        swipe_velocity: 0.7,
        swipe_min_touches: 1,
        swipe_max_touches: 1,
        drag_block_vertical: false,

        parallax: "mouse",
        parallaxBgFreeze: "on",
        parallaxLevels: [7, 4, 3, 2, 5, 4, 3, 2, 1, 0],

        keyboardNavigation: "off",

        navigationHAlign: "center",
        navigationVAlign: "bottom",
        navigationHOffset: 0,
        navigationVOffset: 20,

        soloArrowLeftHalign: "left",
        soloArrowLeftValign: "center",
        soloArrowLeftHOffset: 20,
        soloArrowLeftVOffset: 0,

        soloArrowRightHalign: "right",
        soloArrowRightValign: "center",
        soloArrowRightHOffset: 20,
        soloArrowRightVOffset: 0,

        shadow: 0,
        fullWidth: "on",
        fullScreen: "on",

        spinner: "spinner4",

        stopLoop: "off",
        stopAfterLoops: -1,
        stopAtSlide: -1,

        shuffle: "off",

        autoHeight: "off",
        forceFullWidth: "off",



        hideThumbsOnMobile: "off",
        hideNavDelayOnMobile: 1500,
        hideBulletsOnMobile: "off",
        hideArrowsOnMobile: "off",
        hideThumbsUnderResolution: 0,

        hideSliderAtLimit: 0,
        hideCaptionAtLimit: 0,
        hideAllCaptionAtLilmit: 0,
        startWithSlide: 0,
        videoJsPath: "rs-plugin/videojs/",
        fullScreenOffsetContainer: ""
    });

    // Floating Sidebar Script comment by govind
    //var $sidebar = jQuery("#floating-sidebar"),
    //    offset = $sidebar.offset(),
    //    $scrollHeight = jQuery("#fs-content").height(),
    //    $scrollOffset = jQuery("#fs-content").offset(),
    //    $window = jQuery(window),
    //    $headerHeight = 0;
    //$window = $(window);
    //var sidebarOffset = $sidebar.offset();

    //$window.scroll(function() {
     //   if ($window.width() > 960) {
     //       if ($window.scrollTop() + $headerHeight + 3 > offset.top) {
     //           if ($window.scrollTop() + $headerHeight + $sidebar.height() + 50 < $scrollOffset.top + $scrollHeight) {
      //              $sidebar.stop().animate({
       //                 marginTop: $window.scrollTop() - offset.top + $headerHeight + 30
        //            });
        //        } else {
         //           $sidebar.stop().animate({
          //              marginTop: ($scrollHeight - $sidebar.height() - 80) + 30
           //         });
           //     }
           // } else {
            //    $sidebar.stop().animate({
           //         marginTop: 0
           //     });
          //  }
        //} else {
       //     $sidebar.css('margin-top', 0);
       // }
   // });  comment end by govind

    // Progressbar
    $('.b-progress-bar').each(function() {
        var cap = parseInt($(this).attr('data-capacity'), 10),
            val = parseInt($(this).attr('data-value'), 10),
            len = 100 * (val / cap) + '%';

        $(this).find('.progress-line').css('width', len);

    });

    // Skills 
    $('#skills').appear(function() {
        $(".progress-scale div").removeClass("no-width-skills");
    }, {
        accX: 0,
        accY: -200
    });


    $('#skills2').appear(function() {
        $('.chart').easyPieChart({
            barColor: '#000000'
        });

        $('.chart-color2').easyPieChart({
            barColor: '#7cc623'
        });

        $('.chart-color3').easyPieChart({
            barColor: '#0FA2D5'
        });

        $('.chart-color4').easyPieChart({
            barColor: '#FF4862'
        });

    }, {
        accX: 0,
        accY: -200
    });

    // TESTIMONIAL

    $("#testimonial").owlCarousel({
        autoPlay: 3000,
        stopOnHover: true,
        navigation: true,
        pagination: false,
        slideSpeed: 600,
        singleItem: true,
        autoHeight: true
    });

    // BLOG SLIDER	  
    $("#blog-slider").owlCarousel({

        navigation: true, // Show next and prev buttons
        slideSpeed: 300,
        pagination: false,
        paginationSpeed: 400,
        singleItem: true

    });

    // TEAM CAROUSEL

    var owl = $("#home-team");

    owl.owlCarousel({

        itemsCustom: [
            [0, 2],
            [450, 2],
            [600, 2],
            [700, 2],
            [1000, 5],
            [1200, 5],
            [1400, 5],
            [1600, 5]
        ],
        pagination: false,
        navigation: true

    });

    // 5 COL CAROUSEL

    var owl = $("#carousel_five");

    owl.owlCarousel({

        itemsCustom: [
            [0, 2],
            [450, 3],
            [600, 3],
            [700, 4],
            [1000, 5],
            [1200, 5],
            [1400, 5],
            [1600, 5]
        ],
        pagination: false,
        navigation: true

    });

    // QUOTE CAROUSEL  

    var owl = $("#home-quote");

    owl.owlCarousel({

        itemsCustom: [
            [0, 2],
            [450, 1],
            [600, 2],
            [700, 2],
            [1000, 2],
            [1200, 2],
            [1400, 2],
            [1600, 2]
        ],
        pagination: true,
        navigation: false

    });

    // FLICKRFEED

    $('#flickr').jflickrfeed({
        limit: 9,
        qstrings: {
            id: '51035555243@N01'
        },
        itemTemplate: '<li><a href="{{image_b}}"><img src="{{image_s}}" alt="{{title}}" /></a></li>'
    });

    // ACCORDION

    $('#accordion .collapse').on('shown.bs.collapse', function() {
        $(this).parent().find(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
        $(this).parent().addClass("active");
    }).on('hidden.bs.collapse', function() {
        $(this).parent().find(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
        $(this).parent().removeClass("active");
    });



    $('#accordion-e1 .collapse').on('shown.bs.collapse', function() {
        $(this).parent().find(".fa-chevron-right").removeClass("fa-chevron-right").addClass("fa-chevron-down");
    }).on('hidden.bs.collapse', function() {
        $(this).parent().find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-right");
    });


    $('#accordion-e2 .collapse').on('shown.bs.collapse', function() {
        $(this).parent().find(".icon-plus2").removeClass("icon-plus2").addClass("icon-minus2");
    }).on('hidden.bs.collapse', function() {
        $(this).parent().find(".icon-minus2").removeClass("icon-minus2").addClass("icon-plus2");
    });


    $('#accordion-e3 .collapse').on('shown.bs.collapse', function() {
        $(this).parent().find(".icon-cross2").removeClass("icon-cross2").addClass("icon-check2");
    }).on('hidden.bs.collapse', function() {
        $(this).parent().find(".icon-check2").removeClass("icon-check2").addClass("icon-cross2");
    });

    $('#stats1').appear(function() {

    $('.count1').each(function() {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 2000,
            easing: 'swing',
            step: function(now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

    }, {
        accX: 0,
        accY: -50
    });

    $('#stats2').appear(function() {

    $('.count2').each(function() {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 2000,
            easing: 'swing',
            step: function(now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

    }, {
        accX: 0,
        accY: -50
    });


    $('#stats3').appear(function() {

    $('.count3').each(function() {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 2000,
            easing: 'swing',
            step: function(now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

    }, {
        accX: 0,
        accY: -50
    });

    // FULLWIDTH SEARCH
$(".ss-trigger").click(function() {
	$(".ss-content").addClass("ss-content-act");
});
$(".ss-close").click(function() {
	$(".ss-content").removeClass("ss-content-act");
});

    // STICKY HEADER
    $("header").sticky({topSpacing:0});

    // Countdown Timer
    var endDate = "March 20, 2016";
        $('.countdown.styled').countdown({
          date: endDate,
          render: function(data) {
            $(this.el).html("<div>" + this.leadingZeros(data.days, 3) + " <span>days</span></div><div>" + this.leadingZeros(data.hours, 2) + " <span>hrs</span></div><div>" + this.leadingZeros(data.min, 2) + " <span>min</span></div><div>" + this.leadingZeros(data.sec, 2) + " <span>sec</span></div>");
          }
    });

    $('.mp-lightbox').magnificPopup({
  removalDelay: 300,
        type: 'image',
        closeOnContentClick: true,
  mainClass: 'mfp-fade',
        image: {
            verticalFit: true
        },
 gallery:{
    enabled:true
  }
    });
  

		// SETTINGS PANEL

		$('.btn-settings').on('click', function() {
			$(this).parent().toggleClass('active');
		});

		$('.switch-handle').on('click', function() {
			$(this).toggleClass('active');
			$('.outer-wrapper').toggleClass('boxed');
			
		});

		$('.bg-list div').on('click', function() {
			if ($(this).hasClass('active')) return false;
			if(!$('.switch-handle').hasClass('active')) $('.switch-handle').trigger('click');

			$(this).addClass('active').siblings().removeClass('active');    
			var cl = $(this).attr('class');
			$('body').attr('class', cl);
		});

		$('.color-list div').on('click', function() {
			if ($(this).hasClass('active')) return false;

			$('link.color-scheme-link').remove();
			
			$(this).addClass('active').siblings().removeClass('active');    
			var src 		= $(this).attr('data-src'),
				colorScheme = $('<link class="color-scheme-link" rel="stylesheet" />');

			colorScheme
				.attr('href', src)
				.appendTo('head');
		});

})(jQuery); // End of use strict


  

// slider
$("#sliderRange")
    .slider({
        range: true,
        min: 0,
        max: 500,
        step: 1,
        values: [75, 300],
        slide: function(event, ui) {
            var price1 = ui.values[0];
            var price2 = ui.values[1];
            $("#price1")
                .val("\u20ac" + price1);
            $("#price2")
                .val("\u20ac" + price2);
        }
    });
$('#price1')
    .bind('keyup', function() {
        var from = $(this)
            .val();
        var to = $('#price2')
            .val();
        $('#sliderRange')
            .slider('option', 'values', [from, to]);
    });
$('#price2')
    .bind('keyup', function() {
        var from = $('#price1')
            .val();
        var to = $(this)
            .val();
        $('#sliderRange')
            .slider('option', 'values', [from, to]);
    });

$(window).load(function() {
    "use strict";
    // Isotope
    var $container = $('#blog-mason');
    $container.isotope({
        itemSelector: '.bm-item'
    });
    var $optionSets = $('#portfolio .folio-filter'),
        $optionLinks = $optionSets.find('a');
    $optionLinks.click(function() {
        var $this = $(this);
        if ($this.hasClass('selected')) {
            return false;
        }
        var $optionSet = $this.parents('.folio-filter');
        $optionSet.find('.selected').removeClass('selected');
        $this.addClass('selected');
        // make option object dynamically, i.e. { filter: '.my-filter-class' }
        var options = {},
            key = $optionSet.attr('data-option-key'),
            value = $this.attr('data-option-value');
        value = value === 'false' ? false : value;
        options[key] = value;
        if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
            changeLayoutMode($this, options);
        } else {
            $container.isotope(options);
        }
        return false;
    });
});


$(window).load(function() {
    "use strict";
    // Isotope
    var $container = $('#portfolio-home');
    $container.isotope({
        itemSelector: '.project-item'
    });
    var $optionSets = $('#portfolio-section .filter'),
        $optionLinks = $optionSets.find('a');
    $optionLinks.click(function() {
        var $this = $(this);
        if ($this.hasClass('selected')) {
            return false;
        }
        var $optionSet = $this.parents('.filter');
        $optionSet.find('.selected').removeClass('selected');
        $this.addClass('selected');
        var options = {},
            key = $optionSet.attr('data-option-key'),
            value = $this.attr('data-option-value');
        value = value === 'false' ? false : value;
        options[key] = value;
        if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
            changeLayoutMode($this, options);
        } else {
            $container.isotope(options);
        }
        return false;
    });
});

	var tabLinK = $('.about-post a'),
		tabContenT = $('.tab-cont');

		tabLinK.on('click', function(event){
			event.preventDefault();
			var dataLink = $(this).attr('data-link'),
				dataTab = $('.tab-cont.active').attr('data-tab');

			if(!$(this).hasClass('active')) {
				$('.about-post a').removeClass('active');
				$(this).addClass('active');
			}

			if ( dataLink == dataTab ) {
			} else {
				tabContenT.removeClass('active');
				$('.tab-cont[data-tab='+ dataLink +']').addClass('active');
			}
		});

	// CONTACT FORM

		$('.b-contact-form').submit(function(){

			var self	= $(this),
				action  = self.attr('action');

			self.prev().slideUp(750,function() {
				self.prev().hide();

		 		var name  = self.find('.field-name'),
		 			subj  = self.find('.field-subject'),
		 			email = self.find('.field-email'),
		 			comm  = self.find('.field-comments');

				$.post(action, {
					name: name.val(),
					email: email.val(),
					subject: subj.val() || '...',
					comments: comm.val(),
				},
					function(data){
						self.prev().html(data);
						self.prev().slideDown('slow');

						if (data.match('success') != null) {
							name.val('');
							subj.val('');
							email.val('');
							comm.val('');
						}
					}
				);

			});

			return false;

		});
	
//preloader /
$(document).ready(function () {

  // preloader
  $(window).load(function(){
    $('.preloader').delay(400).fadeOut(500);
  })

})	