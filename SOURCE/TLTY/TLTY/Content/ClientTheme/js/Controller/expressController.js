var request = {
	init: function() {
		request.registerEvents();
	},
	registerEvents: function() {
		$('#btnSend').off('click').on('click', function() {
			var name = $('#txtName').val();
			var phone = $('#txtPhone').val();
			var email = $('#txtEmail').val();
			var details = $('#txtDetail').val();
			var contentid = @Model.ID;


			var div = document.getElementById('thongbao');
			var div2 = document.getElementById('uphinh');
			$.ajax({
				url: '/Express/Requests',
				type: 'POST',
				dataType: 'json',
				data: {
					name: name,
					phone: phone,
					email: email,
					details: details,
					contentid: contentid
				},
				success: function(res) {
					div.style.display = 'block';
					if (res.status === true) {
						div2.style.display = 'block';
						request.upload(parseInt(res.requestid));
						$('.abc').html("<i class='fa fa-check'></i>" + res.msg);
						request.resetForm();
					}
					if (res.status === false) {
						$('.abc').html("<i class='fa fa-times'></i>" + res.msg);
					}
				}
			});
		});
	},
	upload: function(id) {
		var div = document.getElementById('thongbao');
		$("#imageUploadForm").change(function() {
			var formData = new FormData();
			var totalFiles = document.getElementById("imageUploadForm").files.length;
			for (var i = 0; i < totalFiles; i++) {
				var file = document.getElementById("imageUploadForm").files[i];

				formData.append("imageUploadForm", file);
			}
			formData.append("requestid", id);
			$.ajax({
				type: "POST",
				url: '/Express/Upload',
				data: formData,
				dataType: 'json',
				contentType: false,
				processData: false
			});
			div.style.display = 'block';
			$('.abc').html("<i class='fa fa-check'></i> Thêm hình thành công! chúng tôi sẽ xác nhận sau!");
		});
	},
	resetForm: function() {
		$('#txtName').val('');
		$('#txtPhone').val('');
		$('#txtEmail').val('');
		$('#txtDetail').val('');
	}
}
request.init();