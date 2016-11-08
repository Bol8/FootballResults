

$(document).ready(function () {

    $('.masterTooltip').hover(function () {
        // Hover over code
        alert("Hola");
        var title = $(this).attr('title');


        $(this).data('tipText', title).removeAttr('title');

        //$(this).fadeIn('slow');

        //$('.Mytooltip').show();

        $('<p class="Mytooltip"></p>')
        .text(title)
        .appendTo('body')
        .fadeIn('slow');

    }, function () {
        // Hover out code
        $(this).attr('title', $(this).data('tipText'));
        $('.Mytooltip').remove();
    }).mousemove(function (e) {
        var mousex = e.pageX + 20; //Get X coordinates
        var mousey = e.pageY - 40; //Get Y coordinates
        $('.Mytooltip')
        .css({ top: mousey, left: mousex })
    });
});
