$(function () {

    window.content = null;

    var editor = editormd("editormd", {
        path: "/lib/editor.md/lib/",
        height: 400,
        width: "100%",
        onchange: function () {
           window.content = this.getMarkdown()||'';
        }
    });
});