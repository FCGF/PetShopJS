// Product Filter
	$(window).load(function() {
	  "use strict";
	var $container = $('.portfolio-items');
	$container.isotope({
		layoutMode: "masonry",
		masonry: {
			columnWidth: 5
		},
		itemSelector : '.item',
		transitionDuration: '0.8s'
	});
	var $optionSets = $('.project-filter'),
		$optionLinks = $optionSets.find('a');
	$optionLinks.click(function(){
		var $this = $(this);
		// don't proceed if already selected
		if ( $this.hasClass('active') ) {
			return false;
		}
		var $optionSet = $this.parents('.project-filter');
		$optionSet.find('.active').removeClass('active');
		$this.addClass('active');
	// make option object dynamically, i.e. { filter: '.my-filter-class' }
	var options = {},
		key = $optionSet.attr('data-option-key'),
		value = $this.attr('data-option-value');
		
	// parse 'false' as false boolean
	value = value === 'false' ? false : value;
	options[ key ] = value;
		if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
		changeLayoutMode( $this, options );
	} else {
		// otherwise, apply new options
		$container.isotope( options );
	}    
	return false;
	});
});


// Product Filter
	$(window).load(function() {
	  "use strict";
	var $container = $('.newsfeed');
	$container.isotope({
		itemSelector : '.newsfeed .item',
	});
	var $optionSets = $('.newsfeed-filter'),
		$optionLinks = $optionSets.find('a');
	$optionLinks.click(function(){
		var $this = $(this);
		// don't proceed if already selected
		if ( $this.hasClass('active') ) {
			return false;
		}
		var $optionSet = $this.parents('.newsfeed-filter');
		$optionSet.find('.active').removeClass('active');
		$this.addClass('active');
	// make option object dynamically, i.e. { filter: '.my-filter-class' }
	var options = {},
		key = $optionSet.attr('data-option-key'),
		value = $this.attr('data-option-value');
		
	// parse 'false' as false boolean
	value = value === 'false' ? false : value;
	options[ key ] = value;
		if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
		changeLayoutMode( $this, options );
	} else {
		// otherwise, apply new options
		$container.isotope( options );
	}    
	return false;
	});
});

// Product Filter
	$(window).load(function() {
	  "use strict";
	var $container = $('.portfolio-feed');
	$container.isotope({
		itemSelector : '.portfolio-feed .item',
	});
	var $optionSets = $('.portfolio-feed-filter'),
		$optionLinks = $optionSets.find('a');
	$optionLinks.click(function(){
		var $this = $(this);
		// don't proceed if already selected
		if ( $this.hasClass('active') ) {
			return false;
		}
		var $optionSet = $this.parents('.portfolio-feed-filter');
		$optionSet.find('.active').removeClass('active');
		$this.addClass('active');
	// make option object dynamically, i.e. { filter: '.my-filter-class' }
	var options = {},
		key = $optionSet.attr('data-option-key'),
		value = $this.attr('data-option-value');
		
	// parse 'false' as false boolean
	value = value === 'false' ? false : value;
	options[ key ] = value;
		if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
		changeLayoutMode( $this, options );
	} else {
		// otherwise, apply new options
		$container.isotope( options );
	}    
	return false;
	});
});



