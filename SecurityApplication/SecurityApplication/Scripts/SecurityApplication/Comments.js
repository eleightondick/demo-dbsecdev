var Comments = /** @class */ (function () {
    function Comments() {
    }
    Comments.loadTable = function (allowInsecure) {
        $.ajax({
            type: "GET",
            cache: false,
            data: { allowInsecure: allowInsecure },
            url: "/Comments/GetTable",
            success: function (data) {
                $("#CommentsTable").html(data);
            },
            error: function (data) {
                alert("An error happened loading the table: " + data);
            }
        });
    };
    Comments.saveComment = function () {
    };
    return Comments;
}());
//# sourceMappingURL=Comments.js.map