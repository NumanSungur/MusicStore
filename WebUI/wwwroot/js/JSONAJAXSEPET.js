﻿function JSSepetEkle(ProductIDs) {
    $.ajax({
        type: "POST",
        url: "/Home/SepetEkle",
        data: { ID: '' + ProductIDs + '' },
        dataType: "json",
        success: function (responseS) {
            $("#SepetKontrol").load("/PartialView/SepetAdetKontrol");
            alert(responseS);
        },
        failure: function (responseS) {
        },
        error: function (responseS) {
        }
    });
};
function JSSepetDelete(ProductIDs) {
    $.ajax({
        type: "POST",
        url: "/Basket/SepetDelete",
        data: { ID: '' + ProductIDs + '' },
        dataType: "json",
        success: function (responseS) {
            $("#SepetKontrol").load("/PartialView/SepetAdetKontrol");
            $("#SepetDiv").load("/Basket/PartialSepetGet");
        },
        failure: function (responseS) {
        },
        error: function (responseS) {
        }
    });
};
