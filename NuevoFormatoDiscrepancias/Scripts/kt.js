function setSelectValue() {
    $.ajax({
        dataType: "json",
        url: "SetSelected",
        success: function (data) {
            $("#Carriles").data("kendoMultiSelect").value(data);
        }
    });
}