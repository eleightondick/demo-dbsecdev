class Comments {
    public static saveComment(event: Event) {
        event.preventDefault();
        alert("In SaveComment");
        $("#commentForm").submit();
    }
}