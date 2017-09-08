$("#btnInThongKe").click(function (e) {
	e.preventDefault();
	var d = new Date();
	var s = d.getSeconds();
	var m = d.getMinutes();
	var h = d.getHours();
	var day = d.getDay();
	var date = d.getDate();
	var month = d.getMonth();
	var year = d.getFullYear();
	var days = new Array("Chủ nhật", "Thứ hai", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7");
	var months = new Array("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"); var am_pm;
	if (s < 10) { s = "0" + s }
	if (m < 10) { m = "0" + m }
	var ampm = "Sáng";
	if (h > 12)
	{ h -= 12; ampm = "Chiều" }
	if (h < 10) { h = "0" + h }
	var ngay = days[day] + " - Ngày: " + date + " / " + months[month] + " / " + year + " - " + h + ":" + m + ":" + s + " - " + ampm;
	var bang = $('thead tr').html() + '<br/>';
	var dulieu = $('tbody').html();// + '<br/>';
	var name = '<h2 style="text-align:center;text-transform:uppercase">' + $(".page-header").html() + '</h2>';
	var content = name + "<div><h5 style='text-align:right'>" + ngay + "</h5>" + "<hr/><div><table>" + bang + dulieu + "<table></div><hr/></div>";

	InThongKe(content);
});
function InThongKe(content) {
	var printWindow = window.open('', '', 'height = 900; width= 1000');
	printWindow.document.write('<html><head><title>Danh sách</title>');
	printWindow.document.write('<style>table{border-collapse: collapse;width:100%}table, th, td{border: 1px solid #999;}td{padding-left:5px}img{height:30px;width:30px; margin:5px;}</style>');
	printWindow.document.write('</head><body style="height:900px;width:800px;background: #521a61 linear-gradient(55.93deg, #dafffe 0, #fff0f5 100%)">');
	printWindow.document.write(content);
	printWindow.document.write('<h5 style="text-align:left ">Thung Lũng Tình Yêu - Khánh Vinh IT</h5');
	printWindow.document.write('</body></html>');
	printWindow.document.close();
	printWindow.print();
}
//Viết bởi KhanhsVinhIT copy nhớ ghi nguồn