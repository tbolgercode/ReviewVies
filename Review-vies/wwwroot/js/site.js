// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#ajaxTest").click(function () {

    //"movies" will be set to an array of javascript objects. You can access the properties of each object using '.' and the name of the property.
    var movies = GetMoviesArray();


    //these just show the results
    console.log(movies[0].title);
    console.log(movies[0].director);
    console.log(movies[0].scale);
    console.log(movies[0].rating);
    console.log(movies[1].title);
    console.log(movies[1].director);
    console.log(movies[1].scale);
    console.log(movies[1].rating);
    console.log(movies[2].title);
    console.log(movies[2].director);
    console.log(movies[2].scale);
    console.log(movies[2].rating);
    console.log(movies[3].title);
    console.log(movies[3].director);
    console.log(movies[3].scale);
    console.log(movies[3].rating);
    console.log(movies[4].title);
    console.log(movies[4].director);
    console.log(movies[4].scale);
    console.log(movies[4].rating);












    //This just displays a movie on screen. You can display the info however you like (though a bootstrap "card" would probably be best)
    $("#ajaxResult").html(
        "<div class=\"card\" style=\"width: 500px;\">" +
            "<div class=\"row no-gutters\">" +
                "<div class=\"col-sm-5\">" +
                    "<img class=\"card-img\" src=\"" + movies[0].poster + "\">"+
                "</div>" +
                    "<div class=\"col-sm-7\">" +
                        "<div class=\"card-body\">" +
                            "<h5 class=\"card-title\">" + movies[0].title + "</h5>" +
                            "<p class=\"card-text\">Director: " + movies[0].director + "</p>" +
                            "<a href=\"/movie/" + movies[0].id + "\" class=\"btn btn-primary\">View Movie</a>" +
                        "</div>" +
                    "</div>" +
                "</div>" +
            "</div>"
    )
});

function GetMoviesArray() {
    //this ajax call returns json data
    return $.ajax({
        type: "GET",
        url: "/api/sample",
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
}

