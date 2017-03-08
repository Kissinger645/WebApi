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
            render1(rlist);
        });

    });

    function render1(reviews) {
        var rTt = $("#rtitles");
        rTt.empty();
        for (idx in reviews) {
            var rTitle = reviews[idx].Title.Title;
            var rName = reviews[idx].RaterName.Name;
            var rating = reviews[idx].Rating;
            rTt.append("<li>" + rTitle + " - " + rName + " - " + rating + "</li>");
        }
    }

    $("#getRat").click(function () {

        $.get("http://localhost:50692/api/rater", function (rtlist) {
            console.log(rtlist);
            render2(rtlist);
        });

    });

    function render2(raters) {
        var raTt = $("#raters");
        raTt.empty();
        for (idx in raters) {
            var name = raters[idx].Name;
            var age = raters[idx].Age;
            var occ = raters[idx].Occupation
            raTt.append("<li>" + name + ' ' + age + ' ' + occ + "</li>");
        }
    }

});

