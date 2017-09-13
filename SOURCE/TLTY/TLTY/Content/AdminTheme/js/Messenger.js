function closeelement() {
	var div = document.getElementById('closeelement');
	div.style.display = 'none';
}
//setTimeout(closeelement, 5000);
$('#closeelement').delay(9000).slideUp(1500);

function closeBox() {
	var div = document.getElementById('thongbao');
	div.style.display = 'none';
}
setTimeout(closeBox, 9000);