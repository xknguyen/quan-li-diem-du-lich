var content = {
    init: function () {
        content.registerEvents2();
    },
    registerEvents2: function () {
        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManage').modal('show');
            $('#contentID').val($(this).data('id'));
            content.LoadImages();
        });

        $('#btnChooImages').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#imageList').append('<div class="xoahinh" style="float:left;"><img src="' + url + '" width="100" height="100" /><a href="#" class="btn-delImage" title="Xóa ảnh"><button type="button" class="close">X</button></a></div>');
                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });
            };
            finder.popup();
        });
        $('#btnSaveImages').off('click').on('click', function () {
            var images = [];
            var id = $('#contentID').val();//hid
            var div = document.getElementById('thongbao');
	        $.each($('#imageList img'), function(i, item) {
		        images.push($(item).prop('src'));
	        });
            $.ajax({
                url: '/Admin/Contents/SaveImages',
                type: 'POST',
                data: {
                    id: id,
                    images: JSON.stringify(images)
                },
                dataType: 'json',
                success: function (response) {
                	div.style.display = 'block';
                    if (response.status) {
                        $('#imagesManage').modal('hide');
                        $('#imageList').html('');
                        $('.abc').html("<i class='fa fa-check'></i> Lưu hình thành công.");
                    }
                }
            });
        });

    },
    LoadImages: function () {
        $.ajax({
            url: '/Admin/Contents/LoadImages',
            type: 'GET',
            data: {
                id: $('#contentID').val()
            },
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                if (response.data != null) {
                	$.each(data, function (i, item) {
                		html += '<div style="float:left;"><img src="' + item + '" width="100" height="100" /><a href="#" class="btn-delImage" title="Xóa ảnh"><button type="button" class="close">X</button></a></div>';
                	});
                	$('#imageList').html(html);
                	$('.btn-delImage').off('click').on('click', function (e) {
                		e.preventDefault();
                		$(this).parent().remove();
                	});
                }
            }
        });
    }
}
content.init();