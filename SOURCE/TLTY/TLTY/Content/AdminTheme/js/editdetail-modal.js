$('.edit-link').click(function (e) {
	var a_href = $(this).attr('href');
	e.preventDefault();
	$.ajax({
		url: a_href,
		type: 'GET',
		contentType: 'application/json; charset=utf-8',
		success: function (data) {
			$('#editModal').modal('hide');
			$('#detailModal').modal('hide');
			$('.body-content').prepend(data);
			$('#editModal').modal('show');
		}
	});
});