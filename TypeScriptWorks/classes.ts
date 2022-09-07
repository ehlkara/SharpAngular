class Home{
    private _roomNumbers:number;
    _windownumbers:number;
    _floor:number;

    constructor(roomNumbers:number,windownumbers:number,floor:number){
        this._roomNumbers = roomNumbers;
        this._windownumbers = windownumbers;
        this._floor = floor;
    }

    eating(){
        console.log(this._floor + "floor home " +"food eated");
    }

}

let home = new Home(3,4,5)
home.eating();
console.log(home._floor);

class Person{
    public _name:string

    get name():string{
        return "Mr: " + this._name;
    }

    set name(firstName:string) {
        this._name = firstName
    }

    save(){
        console.log("Person saved");
    }
}

class Customers extends Person {
    sold(){
        this._name;
        console.log("Sold");
    }
}

class Personal extends Person {
    pay(){
        console.log("Payed");
    }
}

let customer = new Customers();
customer.name = "Ehlullah"
console.log(customer.name);
customer.save();
customer.sold();

let personal = new Personal();
personal.save();
personal.pay();

