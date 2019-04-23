

$(document).on("change", "#car-make", function () {
    console.log()
    let id = $(this).val();
    $.ajax(
        {
            url: "/all/new-announce-ajax/GetCarModel",
            method: "POST",
            data: {makeId:id}
        })
        .done(function (data)
        {
            $("#car-model").html("");
            $("#car-model").append(`<option value="0"> Siyahidan seçin</option>`);
            for (let carModel of data) {
                $("#car-model").append(`<option value="${carModel.id}"> ${carModel.name}</option>`);
            };
        })
        .fail(function (msg) {
            console.log(msg);
        })
})

var data = [];
var l = 0;
var j = 0;



$("input[type='file']").change(function () {
    readURL(this)

});
$(document).on("click", ".remove", function () {
    $(this).parent().remove();
    console.log($(this).attr('id'))
    data.splice($(this).attr('id'), 1);
    l--;
    j--;
    debugger
    var dataLength = data.length;
    console.log($('#PhotoLength'))
    $('#PhotoLength').val(dataLength)
    console.log($('#PhotoLength').val(dataLength))
})


function readURL(input) {
    let elementDiv = document.querySelector("#show-images");
    for (let item of input.files) {
        debugger
        if (item) {
           
            data[j] = item;
            j++;
            var reader = new FileReader();

            reader.onload = function (e) {
                console.log(e);
                let elementDivv = document.createElement("div");
                let element = document.createElement("img");
                let elementI = document.createElement("i");
                let elementSpan = document.createElement("span");
                $(elementSpan)
                    .attr('class', "remove")
                $(elementSpan)
                    .attr('name', e.loaded)
                $(elementSpan)
                    .attr('id', l)
                l++;
                $(elementI)
                    .attr('class', "fas fa-trash-alt")
                $(element)
                    .attr('src', e.target.result);
                elementDivv.appendChild(element);
                elementSpan.appendChild(elementI);
                elementDivv.appendChild(elementSpan);
                elementDiv.append(elementDivv);

            };
            reader.readAsDataURL(item);
        }
    }
    debugger
    var dataLength = data.length;
    console.log($('#PhotoLength'))
    $('#PhotoLength').val(dataLength)
    console.log($('#PhotoLength').val(dataLength))
}



var form = document.getElementById('form');

form.addEventListener('submit', function (evnt) {
    evnt.preventDefault();
});
//sendFile = function (file) {
//    debugger
//    var formData = new FormData();
//    var request = new XMLHttpRequest();
//    let array = $("#category-select").val().split("/")

//    formData.set('file', file);
//    formData.set('name', array[1]);
//    request.open("POST", 'https://localhost:44300/all/new-announce/addfile');
//    request.send(formData);
//};



var k = null;

$(document).on('click', "#lot-announce-type", function () {
    if (k == null) {
        $(this).next().next().css('display', 'block');
        k = $(this).next().next();
    }
    else {
        k.css('display', 'none');
        $(this).next().next().css('display', 'block');
    }
});

$(document).ready(function () {
    $('#btnUpload').on('click', function () {
        debugger
        var files = $('#files').prop("files");
        var fdata = new FormData();
        for (var i = 0; i < data.length; i++) {
            fdata.append("filess", data[i]);
        }
        if (files.length > 0) {
            $.ajax({
                type: "POST",
                url: "/all/new-announce/Upload",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    form.submit();
                }
            });
        }
        else {
            form.submit();
        }
    })
});