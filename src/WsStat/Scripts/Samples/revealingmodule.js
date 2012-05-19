var myRevModuleNamespace = myRevModuleNamespace || {};

myRevModuleNamespace.Calculator = function (eq) {
    // private variables
    var eqCtl = document.getElementById(eq);

    // private functions
    doAdd: function (x, y) {
        var val = x + y;
        eqCtl.innerHTML = val;
    };

    return {
        // public members
        add: doAdd
    };
};

myRevModuleNamespace.SingletonCalculator = function () {
    // private variables
    var eqCtl = document.getElementById(eq);

    // private functions
    doAdd: function (x, y) {
        var val = x + y;
        return val;
    };

    return {
        // public members
        add: doAdd
    };
}();