setInterval(function () {
	var request = {
		init: function () {
			request.loadrequest();
			request.loadfeedback();
			
		},
		loadrequest: function () {
			$.ajax({
				url: '/Admin/Home/RequestMe',
				type: 'GET',
				dataType: 'json',
				success: function (response) {
					var datar = response.data;
					var html = '';
					$('#soluongr').html(' ' + response.count + ' ');
					$.each(datar, function (j, jtem) {
						var d = jtem.CreateDate;
						var re = /-?\d+/;
						var m = re.exec(d);
						var date = new Date(parseInt(m[0]));
						var formattedDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
						var hours = (date.getHours() < 10) ? "0" + date.getHours() : date.getHours();
						var minutes = (date.getMinutes() < 10) ? "0" + date.getMinutes() : date.getMinutes();
						var formattedTime = hours + ":" + minutes;
						formattedDate = formattedTime + "-" + formattedDate;
						html += '<li><a href="/Admin/Requests/Details/' + jtem.ID + '"  title="Xem chi tiết ' + jtem.Name + '" class="detail-link-mes-re"><div><i class="fa fa-comment-o fa-fw"></i>' + jtem.Name + '<span class="pull-right text-muted small">' + formattedDate + '</span></div></a></li>';
					});
					html += '<li class="divider"></li><li><a class="text-center" href="/Admin/Requests"><strong>Xem toàn bộ </strong><i class="fa fa-angle-right"></i></a></li>';
					$('#request').html(html);
					request.openre();
				}
			});
		},
		loadfeedback: function () {
			$.ajax({
				url: '/Admin/Home/FeedbackMe',
				type: 'GET',
				dataType: 'json',
				success: function (response) {
					var data = response.data;
					var html = '';
					$('#soluongf').html(' ' + response.count + ' ');
					$.each(data, function (i, item) {
						var d = item.CreateDate;
						var re = /-?\d+/;
						var m = re.exec(d);
						var date = new Date(parseInt(m[0]));
						var formattedDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
						var hours = (date.getHours() < 10) ? "0" + date.getHours() : date.getHours();
						var minutes = (date.getMinutes() < 10) ? "0" + date.getMinutes() : date.getMinutes();
						var formattedTime = hours + ":" + minutes;
						formattedDate = formattedTime + "-" + formattedDate;
						html += '<li><a href="/Admin/Feedbacks/Details/' + item.ID + '"  title="Xem chi tiết ' + item.Name + '" class="detail-link-mes-fe"><div><strong>' + item.Name + '</strong><span class="pull-right text-muted"><em>' + formattedDate + '</em></span></div><div>' + item.Description + '</div></a></li>';
					});
					html += '<li class="divider"></li><li><a class="text-center" href="/Admin/Feedbacks"><strong>Xem toàn bộ </strong><i class="fa fa-angle-right"></i></a></li>';
					$('#feedback').html(html);
					request.openfe();
				}
			});
		},
		openre: function() {
			$('.detail-link-mes-re').click(function (e) {
				var a_href = $(this).attr('href');
				e.preventDefault();
				$.ajax({
					url: a_href,
					type: 'GET',
					contentType: 'application/json; charset=utf-8',
					success: function (data) {
						$('.body-content').prepend(data);
						$('#detailModal').modal('show');
					}
				});
			});
		},
		openfe: function () {
			$('.detail-link-mes-fe').click(function (e) {
				var a_href = $(this).attr('href');
				e.preventDefault();
				$.ajax({
					url: a_href,
					type: 'GET',
					contentType: 'application/json; charset=utf-8',
					success: function (data) {
						$('.body-content').prepend(data);
						$('#detailModal').modal('show');
					}
				});
			});
		}
	}
	request.init();
}, 1000);