var myNamespace = myNamespace || {};

// Constructor
myNamespace.Calculator = function (eq) {
    // state declaration
    this.eqCtl = document.getElementById(eq);
};

// Prototype definition
myNamespace.Calculator.prototype = function () {
    // private
    var add = function (x, y) {
        var val = x + y;
        this.eqCtl.innerHTML = val;
    };

    // public
    return {
        add : add
    };
}();
