class Comments {
    public static saveComment(event: Event) {
        event.preventDefault();

        var validateCommentP = $("#jsValidateComment").prop('checked');

        if (validateCommentP) {
            var commentText = $($("#Comment").val()).text();
            $("#Comment").val(commentText).change();
        }

        $("#commentForm").submit();
    }
}