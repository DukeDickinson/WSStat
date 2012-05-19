var myNamespace || {};

// Constructor
myNamespace.Calculator = function (eq) {
    this.eqCtl = document.getElementById(eq);
};
// Prototype definition
myNamespace.Calculator.prototype = {
    add: function (x, y) {
        var val = x + y;
        this.eqCtl.innerHTML = val;
    }
};
