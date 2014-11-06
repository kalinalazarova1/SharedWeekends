$.getJSON("http://api.worldweatheronline.com/free/v2/weather.ashx?q=Sofia&format=json&num_of_days=5&key=769d85d400b7ce492029537cc704b", function (res) {
    // TODO: Refresh info every hour
    var weatherArr = '<ul>';
    for (var i = 0; i < 5; i++) {
        var item = {
            max: res.data.weather[i].maxtempC,
            min: res.data.weather[i].mintempC,
            date: res.data.weather[i].date,
            img: res.data.weather[i].hourly[0].weatherIconUrl[0].value
        }
        weatherArr += '<li>' + item.date.split('-').reverse().join('.') + ' <img src=' + item.img + ' style="width: 20px;"/> min: ' + item.min + '&deg;C - max: ' + item.max + '&deg;C' + '</li>'
    }
    weatherArr += '</ul>'
    $('#weather').html(weatherArr);
});