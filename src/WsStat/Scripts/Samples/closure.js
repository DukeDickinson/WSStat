var closureEx = function () {
    var date = new Date(),
        fn = function () {
            return 'closureEx ' + date.getMilliseconds();
        };
    return {
        foo: fn
    };
}()

alert(closureEx.foo());