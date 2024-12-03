
function load() {
    $('#responsive').show();
}
function loadfrmEditSussess() {
    $('#responsive').show();
}
function closedialog(){
    $("#responsive").hide();
}
function onAddSuccess(res) {
        if (res.status) {
            if (res.message != undefined) {
                $('p#notify').text(res.message);
                $('.message-box').css("background-color", "white");
                $('.message-model').show();
                $('.message-model').hide(10000);
                $("#responsive").hide();
                location.reload();
            }
        } else {
            if (res.message != undefined) {
                $('p#notify').text(res.message);
                $('.message-box').css("background-color", "white");
                $('.message-model').show();
                $('.message-model').hide(10000);
            }
        }
}
function don(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
            $("#responsive").hide();
            location.reload();
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function onEditSuccess(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
            $("#responsive").hide();
            location.reload();
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function btndelete(id,control) {

        $('.message-delete').show();    //Event cancel dialog
    $('.huy').click(function () {
        $('.message-delete').hide();
    })
    $('.xoa').on('click', function () {
        debugger;
        $.ajax({
            url: `/Admin/${control}/Delete?id=` + id,
        }).done(function (res) {
            debugger;
            $('.message-delete').hide();
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "#e5e5e5");
            $('.message-model').show();
            $('.message-model').hide(10000);
            location.reload();
        }).fail(function (res) {
            $('.message-delete').hide();
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "#e5e5e5");
            $('.message-model').show();
            $('.message-model').hide(10000);
        })
    })
}
function btnGiaoHang(id, control) {

    $('.message-giao').show();    //Event cancel dialog
    $('.huy').click(function () {
        $('.message-delete').hide();
    })
    $('.xoa').on('click', function () {
        debugger;
        $.ajax({
            url: `/Admin/${control}/GiaoHang?id=` + id,
        }).done(function (res) {
            debugger;
            $('.message-giao').hide();
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "#e5e5e5");
            $('.message-model').show();
            $('.message-model').hide(10000);
            location.reload();
        }).fail(function (res) {
            $('.message-giao').hide();
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "#e5e5e5");
            $('.message-model').show();
            $('.message-model').hide(10000);
        })
    })
}
function login(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
            if (res.phanquyen == 1) {
                location.href = "/Admin/Homes/Index";
            }
            else {
                location.href = "/Home/Index";
            }
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function doimk(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
                location.href = "/Home/Index";
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function register(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
            location.href = "/Home/Index";

        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function thongtin(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
            location.href = "/Home/Index";
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}
function xoagh(id, idbnt, idmau) {
    $.ajax({
        url: '/Cart/Xoa?Id=' + id + '&&IdBNT=' + idbnt + '&&IdMau=' + idmau,
    }).done(function (res) {
        debugger;
        $('.message-delete').hide();
        $('p#notify').text(res.message);
        $('.message-box').css("background-color", "#e5e5e5");
        $('.message-model').show();
        $('.message-model').hide(10000);
        location.reload();
    }).fail(function (res) {
        $('.message-delete').hide();
        $('p#notify').text(res.message);
        $('.message-box').css("background-color", "#e5e5e5");
        $('.message-model').show();
        $('.message-model').hide(10000);
    })
}
function dathang(res) {
    if (res.status) {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
                location.href = "/Home/Index";
        }
    } else {
        if (res.message != undefined) {
            $('p#notify').text(res.message);
            $('.message-box').css("background-color", "white");
            $('.message-model').show();
            $('.message-model').hide(10000);
        }
    }
}