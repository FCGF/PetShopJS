// GOOGLE MAP - COLORED
google.maps.event.addDomListener(window, 'load', init);

function init() {
	var mapOptions = {
		zoom: 11,
		center: new google.maps.LatLng(40.6700, -73.9400), // New York

		styles:

			[{
			"featureType": "all",
			"elementType": "geometry.stroke",
			"stylers": [{
				"visibility": "off"
			}]
		}, {
			"featureType": "all",
			"elementType": "labels",
			"stylers": [{
				"visibility": "off"
			}]
		}, {
			"featureType": "administrative.locality",
			"elementType": "labels.text.fill",
			"stylers": [{
				"visibility": "off"
			}]
		}, {
			"featureType": "administrative.neighborhood",
			"elementType": "labels.text.fill",
			"stylers": [{
				"visibility": "off"
			}]
		}, {
			"featureType": "landscape",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#01C5FF"
			}]
		}, {
			"featureType": "poi.attraction",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#002573"
			}]
		}, {
			"featureType": "poi.business",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#FFED00"
			}]
		}, {
			"featureType": "poi.government",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#D41C1D"
			}]
		}, {
			"featureType": "poi.park",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#002FA7"
			}]
		}, {
			"featureType": "poi.school",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#BF0000"
			}]
		}, {
			"featureType": "road",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#FCFFF6"
			}]
		}, {
			"featureType": "transit.line",
			"elementType": "geometry.fill",
			"stylers": [{
				"saturation": -100
			}]
		}, {
			"featureType": "water",
			"elementType": "geometry.fill",
			"stylers": [{
				"color": "#BCF2F4"
			}]
		}]
	};

	var mapElement = document.getElementById('map-colorful');
	var map = new google.maps.Map(mapElement, mapOptions);
	var marker = new google.maps.Marker({
		position: new google.maps.LatLng(40.6700, -73.9400),
		map: map,
		title: 'Snazzy!'
	});
}
