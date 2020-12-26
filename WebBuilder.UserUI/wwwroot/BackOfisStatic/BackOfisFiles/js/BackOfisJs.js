toastr.options = {
    "closeButton": true,
    "debug": true,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);



function ToggleValueChange(element) {
    var jElement = $(element);
    var jElementValue = jElement.attr("value");
    if (jElementValue == 'true' || jElementValue == true) {
        jElementValue = true;
        jElement.attr("checked", "checked")
    }
    else {
        jElement.removeAttr("checked")
        jElementValue = false;
    }
    jElementValue = !jElementValue;
    jElement.attr("value", jElementValue);
    console.log(jElementValue)
}

function DataTable(tableId, url, type, columnList, data,) {
    console.log("tableid" + tableId)
    var table = $("#" + tableId).DataTable({
        "language": {
            "url": "/BackOfisStatic/Lib/DataTables/Turkish.json"
        },

        ajax: {
            url: url,
            type: type,
            data: data,
            dataSrc: function (json) {
                if (json.statusCode === 200) {
                    toastr["success"](json.message, "Başarılı")
                }
                else if (json.statusCode === 500) {
                    toastr["error"](json.message, "Sunucu tabanlı hata")

                }
                return json.data;
            },
        },
        columns: columnList,
        "responsive": true,
        "lengthChange": false,
        "autoWidth": true,
        "buttons": [
            {
                className: "bg-primary",
                text: "<i class='fas fa-plus'></i><span style='margin-left: 5px'>Yeni</span>",
                action: function (e, dt, node, config) {
                    OpenNewRecordModal();
                }
            },
            { extend: 'copy', text: 'Kopyala', className: 'bg-primary' },
            { extend: 'excel', text: 'Excel İndir', className: 'bg-primary', exportOptions: { columns: ':visible' } },
            { extend: 'pdf', text: 'PDF İndir', className: 'bg-primary' },
            { extend: 'print', text: 'Yazdır', className: 'bg-primary' },
        ],
        initComplete: function () {
            setTimeout(function () {
                table.buttons().container().appendTo('#' + tableId + '_wrapper .col-md-6:eq(0)');
            }, 10);
        }
    })
    console.log($('#' + tableId + '_wrapper.col-md-6:eq(0)'))


    return table;
}


/* Web View Yükleyici*/
/* Back End Servislerinden Arayüz çeker*/
function LoadPage(url, type, location,succesFunc, data) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        success: function (response) {
            console.log(succesFunc)
            if (succesFunc != undefined && succesFunc != null) {
                console.log("run");
                succesFunc();
            }
            $(location).html(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            toastr["error"]("Görünüm Oluştururken bir hata oluştu. Arka servislerde görüntü oluşturulamadı.", "Sunucu Hatası !")
        }
    });
}
