/* Theme Name: Worthy - Free Powerful Theme by HtmlCoder
 * Author:HtmlCoder
 * Author URI:http://www.htmlcoder.me
 * Version:1.0.0
 * Created:November 2014
 * License: Creative Commons Attribution 3.0 License (https://creativecommons.org/licenses/by/3.0/)
 * File Description: Place here your custom scripts
 */

// Closes the Responsive Menu on Menu Item Click
$('#navbar-collapse-1 a').click(function () {
    var href = $(this).attr('href');
    if (href != '#') {
        //alert('pumasok');
        $('#navbar-collapse-1:visible').click();
    }
});

function initialize() {
    // Create an array of styles.
    var styles = [
      {
          stylers: [
            { hue: "#00ffe6" },
            { saturation: -20 }
          ]
      }, {
          featureType: "road",
          elementType: "geometry",
          stylers: [
            { lightness: 100 },
            { visibility: "simplified" }
          ]
      }, {
          featureType: "road",
          elementType: "labels",
          stylers: [
            { visibility: "off" }
          ]
      }
    ];

    // Create a new StyledMapType object, passing it the array of styles,
    // as well as the name to be displayed on the map type control.
    var styledMap = new google.maps.StyledMapType(styles,
      { name: "Styled Map" });


    var myLatlng = new google.maps.LatLng(14.656442, 120.971727);
    var mapOptions = {
        zoom: 18,
        center: myLatlng,
        mapTypeControlOptions: {
            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
        }

    }
    var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    var image = 'images/tcmi-pin.png';

    //Associate the styled map with the MapTypeId and set it to display.
    map.mapTypes.set('map_style', styledMap);
    map.setMapTypeId('map_style');



    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'We gather here!',
        icon: image
    });
}

google.maps.event.addDomListener(window, 'load', initialize);