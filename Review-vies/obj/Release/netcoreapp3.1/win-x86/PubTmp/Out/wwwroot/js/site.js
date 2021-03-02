// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$("#ajaxTest").click(function () {

    //"movies" will be set to an array of javascript objects. You can access the properties of each object using '.' and the name of the property.
    var movies = GetMoviesArray();


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
                            "<p class=\"card-text\">Rating: " + moviess[0].rating + "</p>" + 
                            "<p class=\"card-text\">Quality: " + moviess[0].scale + "/5</p>" + 
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

function MakeMovieCard(movie) {
    return "<div class=\"col-6 mb-2\">" +
    "<div class=\"card\" style=\"width: 500px;\">" +
        "<div class=\"row no-gutters\">" +
        "<div class=\"col-sm-5\">" +
        "<img class=\"card-img\" style=\"width: 200px; height: 300px\" src=\"" + movie.poster + "\">" +
        "</div>" +
        "<div class=\"col-sm-7\">" +
        "<div class=\"card-body\">" +
        "<h5 class=\"card-title\">" + movie.title + "</h5>" +
        "<p class=\"card-text\">Director: " + movie.director + "</p>" +
        "<p class=\"card-text\">Rating: " + movie.rating + "</p>" +
        "<p class=\"card-text\">Quality: " + movie.scale + "/5</p>" +
        "<a href=\"/movie/" + movie.id + "\" class=\"btn btn-primary\">View Movie</a>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>"
}
function GetReccommended() {
    var movies = GetMoviesArray();

    var htmlstring = "<div class=\"row\">";
    htmlstring = htmlstring + MakeMovieCard(movies[0]) + MakeMovieCard(movies[1]) + "</div>";
    htmlstring = htmlstring + "<div class=\"row\">";
    htmlstring = htmlstring + MakeMovieCard(movies[2]) + MakeMovieCard(movies[3]) + "</div>";



    $("#exampleMovies").html(htmlstring);

}
window.onload = GetReccommended();