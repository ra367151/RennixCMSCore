$(function () {

    window.content = null;
    window.editor = null;

    window.editor = editormd("editormd", {
        path: "/lib/editor.md/lib/",
        height: 400,
        width: "100%",
        saveHTMLToTextarea:true,
        onchange: function () {
           window.content = this.getMarkdown()||'';
        }
    });
});