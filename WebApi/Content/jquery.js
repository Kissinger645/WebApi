$().ready(function () {

    $("#getM").click(function() {

        $.get("http://localhost:50692/api/movie", function(mlist) {
            console.log(mlist);
            render(mlist);
        });

    });

    function render(movies) {
        var titl = $("#titles");
        titl.empty();
        for (idx in movies) {
            var title = movies[idx].Title;
            titl.append("<li>" + title + "</li>");
        }
    }
    
    $("#getR").click(function () {

        $.get("http://localhost:50692/api/review", function (rlist) {
            console.log(rlist);
            render(rlist);
        });

    });

    function render(reviews) {
        var rTt = $("#rtitles");
        rTt.empty();
        for (idx in reviews) {
            var rTitle = reviews[idx].Title.Title;

            rTt.append("<li>" + rTitle + "</li>");
        }
    }

    $("#getRat").click(function () {

        $.get("http://localhost:50692/api/rater", function (rtlist) {
            console.log(rtlist);
            render(rtlist);
        });

    });

    function render(raters) {
        var rTt = $("#raters");
        rTt.empty();
        for (idx in raters) {
            var name = raters[idx].Name;
            var age = raters[idx].Age;
            var occ = raters[idx].Occupation
            rTt.append("<li>" + name + ' ' + age + ' ' + occ + "</li>");
        }
    }

});

