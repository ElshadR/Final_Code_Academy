
$(document).on("click", "#commentCheckIn", function () {
    var checkin = false;
    if ($("#checkIn").is(":checked")) {
        checkin = true;
    }
    else {
        checkin = false;
    }
    var id = $(this).data("id");
    var check = $(this).data("check");
    $.ajax({
        url: "/Admin/home/commentEdit",
        datatype: 'json',
        method: "post",
        data: { checkin, id,check }
    })
        .done(function (data) {
            window.location.reload();
        })
        .fail(function (msg) {

        });
});

(function ($) {
  "use strict"; // Start of use strict

  // Toggle the side navigation
  $("#sidebarToggle").on('click',function(e) {
    e.preventDefault();
    $("body").toggleClass("sidebar-toggled");
    $(".sidebar").toggleClass("toggled");
  });

  // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
  $('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function(e) {
    if ($(window).width() > 768) {
      var e0 = e.originalEvent,
        delta = e0.wheelDelta || -e0.detail;
      this.scrollTop += (delta < 0 ? 1 : -1) * 30;
      e.preventDefault();
    }
  });

  // Scroll to top button appear
  $(document).on('scroll',function() {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
      $('.scroll-to-top').fadeIn();
    } else {
      $('.scroll-to-top').fadeOut();
    }
  });

  // Smooth scrolling using jQuery easing
  $(document).on('click', 'a.scroll-to-top', function(event) {
    var $anchor = $(this);
    $('html, body').stop().animate({
      scrollTop: ($($anchor.attr('href')).offset().top)
    }, 1000, 'easeInOutExpo');
    event.preventDefault();
  });

})(jQuery); // End of use strict



//announce edit view remove photo start
$("#announcePhotoA").click(function (event) {
    event.preventDefault();
});
$(document).on("click", "#deletePhoto", function () {
    var photo = $(this).parent().parent().parent();
    var announceid = $(this).data("id");
    var findtable = $(this).data("findtable");
    var photoId = $(this).data("photoid");
    $.ajax(
        {
            url: "/Admin/home/deletephoto",
            method: "POST",
            data: { announceid, findtable, photoId }
        })
        .done(function (data) {
            if (data == "success") {
                photo.remove();
            }
        })
        .fail(function (msg) {
            console.log(msg);
        })
})
//announce edit view remove photo end