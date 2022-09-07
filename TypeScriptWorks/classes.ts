class Home{
    _roomNumbers:number;
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