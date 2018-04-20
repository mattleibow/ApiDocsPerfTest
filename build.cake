#tool "mdoc"

var target = Argument("target", "Default");

Task("Default").Does(() => {
    // find mdoc.exe
    var mdoc = Context.Tools.Resolve("mdoc.exe");

    // update
    var result = StartProcess(mdoc, new ProcessSettings {
        Arguments = @"update --out=./output -lang=DocId --frameworks=./assemblies/frameworks.xml --lib=./references/"
    });
    if (result != 0) {
        throw new Exception ("mdoc failed.");
    }
});

RunTarget(target);