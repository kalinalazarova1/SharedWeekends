window.onload = function () {
    var lattitude = document.getElementById('Lattitude');
    lattitude.addEventListener('input', function () {
        var elem = document.getElementById('location-map');
        var map = document.getElementById('location-map');
        map.setAttribute('data-lat', lattitude.value);
        initialize();
    });

    var longitude = document.getElementById('Longitude');
    longitude.addEventListener('input', function () {
        var elem = document.getElementById('location-map');
        var map = document.getElementById('location-map');
        map.setAttribute('data-lon', longitude.value);
        initialize();
    });
    loadScript();
};

function initialize() {
    var elem = document.getElementById('location-map');
    var lat = Number(elem.getAttribute('data-lat'));
    var lon = Number(elem.getAttribute('data-lon'));
    var title = elem.getAttribute('data-title');
    var myLatlng = new google.maps.LatLng(lat, lon);
    var mapOptions = {
        zoom: 10,
        center: myLatlng
    };

    var map = new google.maps.Map(elem, mapOptions);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: title
    });

    google.maps.event.addListener(map, "rightclick", function (event) {
        var lat = event.latLng.lat();
        var lng = event.latLng.lng();
        var elem = document.getElementById('location-map');
        elem.setAttribute('data-lat', lat);
        elem.setAttribute('data-lon', lng);
        var myLatlng = new google.maps.LatLng(lat, lng);
        var mapOptions = {
            zoom: 10,
            center: myLatlng
        };

        var map = new google.maps.Map(elem, mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: title
        });
        var lattitude = document.getElementById('Lattitude');
        lattitude.value = lat;
        var longitude = document.getElementById('Longitude');
        longitude.value = lng;
    });
}
function loadScript() {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = 'https://maps.googleapis.com/maps/api/js?v=3.exp&' +
        'callback=initialize';
    document.body.appendChild(script);
}