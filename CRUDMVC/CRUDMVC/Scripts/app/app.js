
var app = (function () {
    var refresh = function () {
        window.location.href = window.location.href;
        console.clear();
    };
    var category = {
        confirmDelete: function (e) {
            e.preventDefault();

            var $self = $(this);
            var category = $self.attr('data-name');
            bootbox.confirm('bạn có muốn xóa loại tên "' + category + '" ?', function (yes) {
                if (!yes) return;
                var url = $self.attr('data-url');
                if (!url) return;
                var req = $.ajax({
                    url: url,
                    method: 'post',
                    timeout: 3000,
                    success: function (resp) {
                        console.log(resp);
                        if (!resp || !resp.success) toastr.error(resp.msg || 'unexpected error occurred');

                        $self.closest('tr').fadeOut(250, function () {
                            $(this).remove();
                            toastr.success(resp.msg || "xóa thành công !");
                        });
                    },
                    error: function (jqXHR, stt, err) {
                        console.log(jqXHR);
                        toastr.error(stt || err || 'xóa không thành công');
                    }
                });
            });
        },
    };
    //
    return {
        category: category,
        //
        refresh: refresh,

    };
})();


