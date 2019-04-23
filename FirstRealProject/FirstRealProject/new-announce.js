

$(document).on("change", "#car-make", function () {
    let id = $(this).val();
    debugger
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


$(document).on("click", ".remove", function () {
    console.log(data.splice($(this).prev().attr('id'), 1))
    l--;
    $(this).parent().remove();
})

var data = [];
l = 0;
var checked = true;
document.querySelector("#files")
    .addEventListener("change", function (event) {
        debugger
        files = event.target.files
        for (var i = 0; i < files.length; i++) {
            if (data.length > 8) {
                $("#files").attr('disabled', 'disabled');
                return;
            }
            for (var j = 0; j < data.length; j++) {
                if (data[j].name == files[i].name) {
                    checked = false;
                }
            }
            if (checked) {
                data[l] = files[i];
                readURL(files[i],i)
                l++;
            }
            checked = true;
        }
        
    })
var form = document.getElementById("form");
form.addEventListener('submit', function (evnt) {
    debugger
    data.forEach(function (file) {
        sendFile(file);
    });
});
let count = 0;
sendFile = function (file) {
    debugger
    var formData = new FormData();
    var request = new XMLHttpRequest();
    formData.set('file', file);
    formData.set('count', count);
    count++;
    request.open("POST", `https://localhost:44300/all/new-announce/addfile`);
    request.send(formData);
};
function readURL(item,i) {
    debugger    
    let elementDiv = document.querySelector("#show-images");
    if (item) {
        var reader = new FileReader();

        reader.onload = function (e) {
            let elementDivv = document.createElement("div");
            let element = document.createElement("img");
            let elementI = document.createElement("i");
            let elementSpan = document.createElement("span");
            $(elementSpan)
                .attr('class', "remove")
            $(elementSpan)
                .attr('name', e.loaded)

            $(elementI)
                .attr('class', "fas fa-trash-alt")
            $(element)
                .attr('src', e.target.result);
            $(element)
                .attr('id', i);
            elementDivv.appendChild(element);
            elementSpan.appendChild(elementI);
            elementDivv.appendChild(elementSpan);
            elementDiv.append(elementDivv);

        };
        reader.readAsDataURL(item);
    }
}
