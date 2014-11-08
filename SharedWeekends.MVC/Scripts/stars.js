var $star_rating = $('.f .glyphicon');

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
    $star_rating.siblings('input.rating-value').val($(this).data('rating'));
    return SetRatingStar();
});

window.onload = SetRatingStar();