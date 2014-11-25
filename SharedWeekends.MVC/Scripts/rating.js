$('#postReview').on('click', function () {
    var reviewsText = $('#reviewsCount').html();
    var reviewsIndex = reviewsText.indexOf(' reviews');
    var reviewsCount = parseInt(reviewsText.substr(0, reviewsIndex)) + 1;
    $('#reviewsCount').html(reviewsCount + ' reviews');
});