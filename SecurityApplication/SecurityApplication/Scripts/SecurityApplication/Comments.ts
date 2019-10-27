class Comments {
    public static loadTable(allowInsecure: boolean) {
        $.ajax({
            type: "GET",
            cache: false,
            data: { allowInsecure },
            url: "/Comments/GetTable",
            success(data) {
                $("#CommentsTable").html(data);
            },
            error(data) {
                alert("An error happened loading the table: " + data);
            }
        });
    }

    public static saveComment() {

    }
}