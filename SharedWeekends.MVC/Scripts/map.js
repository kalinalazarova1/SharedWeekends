function initialize() {
    var elem = document.getElementById('location-map');
    if (elem) {
        var lat = Number(elem.getAttribute('data-lat'));
        var lon = Number(elem.getAttribute('data-lon'));
        var title = elem.getAttribute('data-title');
        var myLatlng = new google.maps.LatLng(lat, lon);
        var mapOptions = {
            zoom: 12,
            center: myLatlng
        };

        var map = new google.maps.Map(elem, mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: title
        });
    }
}

function toggleForm() {
    var reviewForm = document.getElementById('review-form');
    if (reviewForm) {
        var button = document.getElementById('review');
        if (reviewForm.style.display == '' || reviewForm.style.display == 'none') {
            reviewForm.style.display = 'block';
            button.innerText = 'Hide Review';
            loadStarControl();
        } else {
            reviewForm.style.display = 'none';
            button.innerText = 'Leave a Review';
        }
    }
}

function loadScript() {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = 'https://maps.googleapis.com/maps/api/js?v=3.exp&' +
        'callback=initialize';
    document.body.appendChild(script);
    var button = document.getElementById('review');
    if (button) {
        button.addEventListener('click', toggleForm);
    } else {
        loadStarControl();
    }
}

window.onload = loadScript;

function loadStarControl() {
    var $star_rating = $('.f.glyphicon');

    var SetRatingStar = function () {
        return $star_rating.each(function () {
            if (parseInt($star_rating.siblings('input.rating-value').val()) >= parseInt($(this).data('rating'))) {
                return $(this).removeClass('f glyphicon glyphicon-star-empty').addClass('f glyphicon glyphicon-star');
            } else {
                return $(this).removeClass('f glyphicon glyphicon-star').addClass('f glyphicon glyphicon-star-empty');
            }
        });
    };

    $star_rating.on('click', function () {
        var ratingValue = $(this).data('rating');
        $star_rating.siblings('input.rating-value').val(ratingValue);
        return SetRatingStar();
    });
}