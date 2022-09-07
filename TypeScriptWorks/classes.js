var Home = /** @class */ (function () {
    function Home(roomNumbers, windownumbers, floor) {
        this._roomNumbers = roomNumbers;
        this._windownumbers = windownumbers;
        this._floor = floor;
    }
    Home.prototype.eating = function () {
        console.log(this._floor + "floor home " + "food eated");
    };
    return Home;
}());
var home = new Home(3, 4, 5);
home.eating();
console.log(home._floor);
