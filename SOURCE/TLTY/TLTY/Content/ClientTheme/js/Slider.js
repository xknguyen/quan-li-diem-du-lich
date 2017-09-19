$('#mySlider').carousel({
	interval: 3500
});
$('#mySlider').on('slide.bs.carousel', function (e) {
	var id = $('.item.active').data('slide-number');
	if (e.direction === 'right') {
		id = parseInt(id) - 1;
		if (id === -1) id = 7;
	} else {
		id = parseInt(id) + 1;
		if (id === $('[id^=carousel-thumb-]').length) id = 0;
	}
	$('[id^=carousel-thumb-]').removeClass('selected');
	$('[id=carousel-thumb-' + id + ']').addClass('selected');
});

$('[id^=carousel-thumb-]').click(function () {
	var idSelector = $(this).attr("id");
	var id = idSelector.substr(idSelector.length - 1);
	id = parseInt(id);
	$('#mySlider').carousel(id);
	$('[id^=carousel-thumb-]').removeClass('selected');
	$(this).addClass('selected');
});