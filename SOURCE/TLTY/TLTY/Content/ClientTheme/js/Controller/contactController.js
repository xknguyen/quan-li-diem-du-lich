var request = {
	init: function () {
		request.registerEvents();
	}, registerEvents: function () {
		$('#btnSend').off('click').on('click', function () {
			var name = $('#txtName').val();
			var phone = $('#txtPhone').val();
			var email = $('#txtEmail').val();
			var details = $('#txtDetail').val();
			var div = document.getElementById('thongbao');
			$.ajax({
				url: '/Contacts/Feedback',
				type: 'POST',
				dataType: 'json',
				data: {
					name: name,
					phone: phone,
					email: email,
					detail: details
				},
				success: function (res) {
					div.style.display = 'block';
					if (res.status === true) {
						$('.abc').html("<i class='fa fa-check'></i>" + res.msg);
						request.resetForm();
					}
					if (res.status === false) {
						$('.abc').html("<i class='fa fa-times'></i>" + res.msg);
					}
				}
			});
		});

	}, resetForm: function () {
		$('#txtName').val('');
		$('#txtPhone').val('');
		$('#txtEmail').val('');
		$('#txtDetail').val('');
	}
}
request.init();