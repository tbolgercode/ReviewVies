
SelectedPoster = "";

function GetPosters() {
    var searchterm = $("#Movie").val();

    var posters =  $.ajax({
        type: "GET",
        url: "/api/getposters?querystring=" + searchterm + " Movie Poster",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            return data;
        },
        error: function (data) {
            return null;
        }
    }).responseJSON;
    var resultHtml = "";
    posters.forEach(function (poster) {
        resultHtml = resultHtml + "<div class=\"justify-content-around\"><img src=\"" + poster.thumbnailUrl + "\" style=\"width: 140px; length: 220px;\" class=\"poster-selection\"></div>"; 
    })

    $("#posterSelection").html(resultHtml);

}

$(document).on('click', '.poster-selection', function (event) {
    var elems = document.querySelectorAll(".selected");
    [].forEach.call(elems, function (el) {
        el.classList.remove("selected");
    });

    SelectedPoster = event.target.getAttribute("src");
    event.target.classList.add("selected");
    $("#posterSelected").val(event.target.getAttribute("src"));
});
