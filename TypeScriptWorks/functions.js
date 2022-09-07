function sum(x, y) {
    return x + y;
}
function sum2(x, y) {
    return x + y;
}
var sum3 = function (x, y) {
    return x + y;
};
console.log(sum(2, 3));
console.log(sum("İstnabul", 2));
console.log(sum2(2, 4));
console.log(sum3(4, 8));
function sum4(x, y) {
    if (y === void 0) { y = 4; }
    return x + y;
}
console.log(sum4(3));
function sum5(x, y) {
    if (y) {
        return x + y;
    }
    return x;
}
console.log(sum5(3, 40));
//Rest Parameters
function invite(firstİnvite) {
    var anothers = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        anothers[_i - 1] = arguments[_i];
    }
    // return firstİnvite + " " + anothers.join(" ");
    return anothers.join(" ");
}
console.log(invite("Ehlullah", "Derin", "Salih", "Ahmet"));
