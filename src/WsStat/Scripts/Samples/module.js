var myModuleNamespace = myModuleNamespace || {};

myModuleNamespace.Calculator = function (eq) {
    // private variables
    var eqCtl = document.getElementById(eq);

    // private functions

    return {
        // public members
        add: function (x, y) {
            var val = x + y;
            eqCtl.innerHTML = val;
        }
    }
};