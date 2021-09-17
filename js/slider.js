var indicador = 0;

$(document).on('ready',function(){
    $('.left').on('click',function(e){
        e.preventDefault();
        moveSlider('left');
    });
    $('.right').on('click',function(e){
        e.preventDefault();
        moveSlider('right');
    });
});


$(window).on('resize', defineSizes());
function defineSizes(){
    $('.form_container .slide').each(function(i,e1){
        $(e1).css({
            'background-image':"url("+$(e1).data("background")+")",
            'height': ($('.form_container').width() * 0.71)+'px',
            'width': ($('.form_container').width())+'px',
        });
    });

    $('.form_container .slideContainer').css({
        'margin-left': -(indicador * $('.form_container').width())+'px'
    });
}

function moveSlider(direccion){
    var limite = $('.form_container .slide').length;

    indicador = (direccion == 'right') ? indicador+1 : indicador-1;
    indicador = (indicador >= limite) ? 0 : indicador;
    indicador = (indicador < 0) ? limite-1 : indicador;

    $('.form_container .slideContainer').animate({
        'margin-left': -(indicador * $('.form_container').width())+'px'
    });
}