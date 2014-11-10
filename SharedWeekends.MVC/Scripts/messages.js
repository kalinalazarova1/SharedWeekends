$('.bold').on('click', 'a', function () {
   var par = $(this).parents('.bold');
   par.removeClass('bold');
});