var x;
var y;
$(document).on("click", ".pagination a", function (e) {
    var id = x;
    console.log("duududdu");
    var page = $(this).data("page");
    $(".pagination li").removeClass("active");
    $(this).parent().addClass("active");
    if (y == null) {
        loadPage(id, page);
    }
    else {
        loadPage2(y, page);
    }
});
function loadPage(id, page) {
    $.ajax({
        url: "/User/FilterProductListByType",
        data: { type: id, page: page, search: y },
        type: "GET",
        success: function (response) {
            $("div#content").html(response);
        }
    });

}
function loadPage2(search, page) {
    $.ajax({
        url: "/User/SearchProductListByType",
        data: { page: page, search: search },
        type: "GET",
        success: function (response) {
            $("div#main").html(response);
        }
    });

}
$(document).on("click", "li.fill a", function (e) {
    var id = $(this).attr("id").trim();
    x = id;
    y = null;
    console.log(id);
    $.ajax({
        url: "/User/FilterProductListByType",
        data: { type: id },
        success: function (response) {
            $("div#content").html(response);
            console.log(id);
        }

    });
});
$("#btnsearch").click(function (e) {
    console.log("run");
    var text = $('#txtsearch').val();
    x = null;
    y = text;
    console.log(text);
    $.ajax({
        url: "/User/SearchProductListByType",
        data: { search: text },
        success: function (response) {
            $("div#main").html(response);
        }

    });
});

//
$(document).on("click", "li.nav-item", function (e) {
    console.log("run");
    var id = $(this).attr("id");
    console.log(id);
    if (id !== undefined) {
        console.log(id);
        if (id == "Index" || id == "About") {
            var url = "User/" + id;
        } else if (id == "ShoppingCart") {
            var url = "Cart/Index";
        }

        $.ajax({
            url: url,
            success: function (response) {

                //$("div#main").html(response);
                var content = $(response).find('div#main').html();
                if (content !== undefined && content.length > 0) {
                    $("div#main").html(content);
                } else {
                    $("div#main").html(response);
                }
            }
        });
    }
});
$(document).on("click", ".card-body a", function (e) {
    var id = $(this).attr("id");
    $.ajax({
        url: "Cart/AddToCart",
        data: { id: id },
        success: function (response) {

            var content = $(response).find('div#main').html();
            if (content !== undefined && content.length > 0) {
                $("div#main").html(content);
            } else {
                $("div#main").html(response);
            }
        }
    });
});