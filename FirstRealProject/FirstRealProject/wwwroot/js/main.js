$(document).ready(function () {

    //index carousel start
    $(document).on("mouseenter", ".announceItem", function () {
        $(this.children[0].children[0].children[0]).carousel({ interval: 2000 });
    });
    $(document).on("mouseleave", ".announceItem", function () {
        $(this.children[0].children[0].children[0]).carousel("pause");
    });
    $(document).on("click", ".select", function () {
        var announceId = $(this).data('id');
        var findTable = $(this).data('tablename');
        var select = $(this);
        if ($(this).hasClass('far')) {
            
            $.ajax({
                url: "/all/home/selected",
                datatype: 'json',
                method: "post",
                data: { announceId: announceId, findTable: findTable }
            })
                .done(function (data) {
                    if (data === "success") {
                        select.removeClass('far')
                        select.addClass('fas')
                    }
                })
                .fail(function (msg) {
                    console.log(msg);
                });
        }
        else {
            $.ajax({
                url: "/all/home/selecteddelete",
                datatype: 'json',
                method: "post",
                data: { announceId: announceId, findTable: findTable }
            })
                .done(function (data) {
                    if (data === "success") {
                        select.removeClass('fas')
                        select.addClass('far')
                    }
                })
                .fail(function (msg) {
                    console.log(msg);
                });
        }

        console.log()
    });

    //index carousel end

    //index comparison start
    var compairCount = 0;
    $(document).on("click", ".comparison", function () {
        var announceId = $(this).data('id');
        var findTable = $(this).data('tablename');
        var compair = $(this);
        if ($(this).hasClass("test")) {
            $.ajax({
                url: "/all/home/compairdelete",
                datatype: 'json',
                method: "post",
                data: { announceId: announceId, findTable: findTable }
            })
                .done(function (data) {
                    if (data === "success") {
                        compairCount--;
                        compair.removeClass("test");
                        if (compairCount >= 2) {
                            debugger
                            console.log($(window).height())
                            console.log($(window).width())
                            var height = $(window).height() - 50;
                            var width = ($(window).width() * 2) / 3;

                            $("#compairButton").css("top", height)
                            $("#compairButton").css("left", width)
                            $("#compairButton").css("display", "inline-block")

                        }
                        else {
                            $("#compairButton").css("display", "none")
                        }
                    }
                })
                .fail(function (msg) {
                    console.log(msg);
                });
           
        } else {
            $.ajax({
                url: "/all/home/compair",
                datatype: 'json',
                method: "post",
                data: { announceId: announceId, findTable: findTable }
            })
                .done(function (data) {
                    if (data === "success") {
                        compairCount++;
                        compair.addClass("test");
                        if (compairCount >= 2) {
                            debugger
                            console.log($(window).height())
                            console.log($(window).width())
                            var height = $(window).height() - 50;
                            var width = ($(window).width() * 2) / 3;

                            $("#compairButton").css("top", height)
                            $("#compairButton").css("left", width)
                            $("#compairButton").css("display", "inline-block")

                        }
                        else {
                            $("#compairButton").css("display", "none")
                        }
                    }
                })
                .fail(function (msg) {
                    console.log(msg);
                });
        }
        

    });
    $(window).resize(function () {
        if (compairCount >= 2) {
            debugger
            console.log($(window).height())
            console.log($(window).width())
            var height = $(window).height() - 50;
            var width = ($(window).width() *2)/3;

            $("#compairButton").css("top", height)
            $("#compairButton").css("left", width)
            $("#compairButton").css("display", "inline-block")

        }
        else
        {
            $("#compairButton").css("display", "none")
        }
    });
    //index comparison end

    //index headerNav start

    //index headerNav end

    //bottomHead Section start
    var w = [0,1];
    $('.searchCatBtnTransport').on('click', function () {
        $(".searchCatBtnTransportList").removeClass('active');
        $(".searchCatBtnTransport").removeClass("headerNavItemActive")
        if (w[0] != $(this).next()[0]) {
            w = $(this).next()
            $(this).next().toggleClass('active');
            $(this).addClass("headerNavItemActive");
        }
        else {
            w = [0, 1];
        }
        
    });
    $(window).on("click", e => {
        var j = $('.searchCatBtnTransportList');
      
        for (var item of j) {
            if ($(item).hasClass("active") && !$(e.target).hasClass("Transportoverlapp")) {
                $(item).toggleClass('active');
                $(item).prev().removeClass("headerNavItemActive")
            }
            
        }
    })
    //bottomHead Section end

})


//-------------------- Dasinmaz emlak start--------------------


$(".select-dropdown__button").click(function (event) {
    event.preventDefault();
});

//search category 

//search city
$('.Cityoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
$('.Categoryoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
$('.Typeoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
$('.BuildingTypeoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
$('.PropertyTypeoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
//neqliyyat car
$('.BodyTypeoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});
$('.Conditionoverlapp').on('click', function () {
    $(this).next().toggleClass('active');
});


$(window).on("click", e => {
    if ($(".searchCityList").hasClass("active") && !$(e.target).hasClass("Cityoverlapp")) {
        $(".searchCityList").toggleClass('active');
    }
    if ($(".searchCategoryList").hasClass("active") && !$(e.target).hasClass("Categoryoverlapp")) {
        $(".searchCategoryList").toggleClass('active');
    }
    if ($(".searchTypeList").hasClass("active") && !$(e.target).hasClass("Typeoverlapp")) {
        $(".searchTypeList").toggleClass('active');
    }
    if ($(".searchBuildingTypeList").hasClass("active") && !$(e.target).hasClass("BuildingTypeoverlapp")) {
        $(".searchBuildingTypeList").toggleClass('active');
    }
    if ($(".searchPropertyTypeList").hasClass("active") && !$(e.target).hasClass("PropertyTypeoverlapp")) {
        $(".searchPropertyTypeList").toggleClass('active');
    }
    if ($(".searchBodyTypeList").hasClass("active") && !$(e.target).hasClass("BodyTypeoverlapp")) {
        $(".searchBodyTypeList").toggleClass('active');
    }
    if ($(".searchConditionList").hasClass("active") && !$(e.target).hasClass("Conditionoverlapp")) {
        $(".searchConditionList").toggleClass('active');
    }
})




$('.searchCityLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchCityBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});
$('.searchTypeLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchTypeBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});
$('.searchBuildingTypeLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchBuildingTypeBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});
$('.searchPropertyTypeLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchPropertyTypeBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});
$('.searchBodyTypeLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchBodyTypeBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});
$('.searchConditionLi').on('click', function () {
    var itemValue = $(this).data('value');
    $('.searchConditionBtn span').text($(this).text()).parent().attr('data-value', itemValue);

    $(this).parent().toggleClass('active');
});

// ----------------------Dasinmaz emlak end-------------------------



//---------------new announce start---------------------
$(document).on("click", "#lot-person-type", function () {
    $('#lot-person-type').not(':checked');
    $(this).is(":checked");
});
$(document).on("click", "#lot-announce-type", function () {
    $('#lot-announce-type').not(':checked');
    $('#lot-announce-type').next().next().css("display", "none");
    $(this).is(":checked");
    $(this).next().next().css("display", "block");
});




//change category start
let selectChange;
$(document).on("change", "#category-select", function () {
    debugger
    for (var i = 1; i < 14; i++) {
        $(`.change-category-${i}`).css("display", "none")
    }
    let array = $("#category-select").val().split("/")
    let select = `.change-category-${array[0]}`;
    if (array[0] === "0") {
        $(".announce-form").attr("action", "index")
    }
    else {
        $(".announce-form").attr("action", array[1])
    }
    if (selectChange != undefined) {
        selectChange.css("display", "none")
    }
    selectChange = $(select);
    $(select).css("display", "block");

})
    //change category end
    //---------------new announce end-------------------



//---------------Comment start---------------
var commentForm = document.getElementById("commentForm");

commentForm.addEventListener("submit", function (evnt) {
    evnt.preventDefault();
    debugger
    commentSender();
   
})
commentSender = function () {
    let email = $('#commentEmail');
    let description = $('#commentDescription');
    let k = false;
    debugger

    $.ajax({
        url: "/all/home/comment",
        datatype: 'json',
        method: "post",
        data: { email: email.val(), description: description.val() }
    })
        .done(function (data) {
            if (data == "success") {
                rem();
                alert("Siznən tezliklə əlaqə saxlanacaq.")
            }
            else {
                k = false;
                alert("Email və ya mətni düzgünlüyünü yoxlayın.")
            }

        })
        .fail(function (msg) {
            console.log(msg);
        });
  
}
rem = function () {
    $('#commentEmail').val("");
    $('#commentDescription').val("")
}

//---------------Comment end---------------


$('a[data-target="#modalDelete"]').click(function () {
    var id = $(this).data('val');
    var fndtable = $(this).data('findtable');
    $("#deletemodalid").val(id);
    $("#deletetablename").val(fndtable);
});


$(document).on('click', '#modalDeleteBtn', function () {
    var id = $("#deletemodalid").val();
    var findtable = $("#deletetablename").val();
    var pincode = $("#inputPassword2").val();
    $.ajax({
        url: "/all/home/deleteannounce",
        datatype: 'json',
        method: "post",
        data: { id: id, findtable: findtable, announcepincode: pincode }
    })
        .done(function (data) {
            if (data == "success") {
                $("#modaldeleteform").submit();
            }
            else {
                $('#deleteMessage').html("pin kod düzgün deyil.")
            }

        })
        .fail(function (msg) {
            console.log(msg);
        });
})