//thông báo
function closeBox() {
	var div = document.getElementById('thongbao');
	div.style.display = 'none';
}
setInterval(closeBox, 9000);
//back
jQuery(document).ready(function ($) {
	$(".btn-top").hide();
	if ($(".btn-top").length > 0) {
		$(window).scroll(function () {
			var e = $(window).scrollTop();
			if (e > 300) {
				$(".btn-top").show();
			} else {
				$(".btn-top").hide();
			}
		});
		$(".btn-top").click(function () {
			$('body,html').animate({
				scrollTop: 0
			});
		});
	}
});
//load
$('body').append('<div id="loadingDiv"><div class="loader"><h3>Đang tải dữ liệu...</h3></div></div>');
$(window).on('load', function () {
	setTimeout(removeLoader, 1000);
});
function removeLoader() {
	$("#loadingDiv").fadeOut(500, function () {
		$("#loadingDiv").remove();
	});
}