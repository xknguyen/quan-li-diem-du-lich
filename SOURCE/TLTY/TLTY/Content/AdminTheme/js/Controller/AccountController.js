﻿var user = {
	init: function () {
		user.registerEvents();
	},
	registerEvents: function () {
		$('.btn-active').off('click').on('click', function (e) {
			e.preventDefault();
			var btn = $(this);
			var id = btn.data('id');
			$.ajax({
				url: "/Admin/Accounts/ChangeStatus",
				data: { id: id },
				dataType: "json",
				type: "POST",
				success: function (response) {
					console.log(response);
					if (response.status == true) {
						btn.text('Kích hoạt');
						$('.abc').html(response.smg);
					}
					else {
						$('.abc').html("<i class='fa fa-times'></i> Khóa thành công.");
						btn.text('Khoá');
					}
				}
			});
		});
	}



}
user.init();