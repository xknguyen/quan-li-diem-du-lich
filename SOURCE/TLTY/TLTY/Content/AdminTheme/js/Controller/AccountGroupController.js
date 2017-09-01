var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var div = document.getElementById('thongbao');
            $.ajax({
                url: "/Admin/AccountGroups/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    div.style.display = 'block';
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                        $('.abc').html("<i class='fa fa-check'></i> Kích hoạt thành công.");
                    }
                    else {
                        btn.text('Khoá');
                        $('.abc').html("<i class='fa fa-check'></i> Khóa thành công.");
                    }
                }
            });
        });
    }
}
user.init();