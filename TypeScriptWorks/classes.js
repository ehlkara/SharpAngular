var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var Person = /** @class */ (function () {
    function Person() {
    }
    Person.prototype.save = function () {
        console.log("Person saved");
    };
    return Person;
}());
var Customers = /** @class */ (function (_super) {
    __extends(Customers, _super);
    function Customers() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Customers.prototype.sold = function () {
        console.log("Sold");
    };
    return Customers;
}(Person));
var Personal = /** @class */ (function (_super) {
    __extends(Personal, _super);
    function Personal() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Personal.prototype.pay = function () {
        console.log("Payed");
    };
    return Personal;
}(Person));
var customer = new Customers();
customer.save();
customer.sold();
var personal = new Personal();
personal.save();
personal.pay();
