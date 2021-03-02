

$("#searchForm").submit(function (event) {

    GenerateMovieCards();
    event.preventDefault();
});

function GenerateMovieCards() {


    var text = $("#SearchInputBox").val();
    var results = SearchMoviesByTitle(text);
    $("#movieResults").html(GetSearchResultsHtml(results));

}

function SearchMoviesByTitle(term) {
    return $.ajax({
        type: "GET",
        url: "/api/searchbytitle?searchterm=" + term,
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

function GetSearchResultsHtml(movies) {
    var htmlstring = "";
    var odd = true;

    

    movies.forEach(function (movie) {
        if (odd) {
            htmlstring = htmlstring + "<div class=\"row ml-1\">";
            
        }
        htmlstring = htmlstring + MakeMovieCard(movie);
        if (!odd) {
            htmlstring = htmlstring + "</div>";
        }

        odd = !odd;
    })

    if (!odd) {
        htmlstring = htmlstring + "</div>";
    }

    return htmlstring;
}

