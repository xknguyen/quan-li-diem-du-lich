jQuery(document).ready(function ($) {
	$('#mySlider2').carousel({
		interval: 5000
	});

	//Handles the carousel thumbnails
	$('[id^=s1name-]').click(function () {
		var idSelector = $(this).attr("id");
		try {
			var id = /-(\d+)$/.exec(idSelector)[1];
			console.log(idSelector, id);
			jQuery('#mySlider2').carousel(parseInt(id));
		} catch (e) {
			console.log('Regex failed!', e);
		}
	});

	// When the carousel slides, auto update the text
	$('#mySlider2').on('slid.bs.carousel', function (e) {
		var id = $('.item.active').data('slide-number');
		$('#carousel-text').html($('#slide-content-' + id).html());
	});
});
//modal
$(document).ready(function () {
	$('img').on('click', function () {
		var image = $(this).attr('src');
		$('#myModalImages').on('show.bs.modal', function () {
			$("#Myid").attr("src", image);
		});
	});
});