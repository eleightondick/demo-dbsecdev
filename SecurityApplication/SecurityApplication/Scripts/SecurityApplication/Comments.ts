class Comments {
    public static saveComment(event: Event) {
        event.preventDefault();

        $("#commentFormEntry").submit();
    }
}