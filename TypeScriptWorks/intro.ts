function greeter(name:string){
    return "Hello " + name
}

let message = greeter("Ehlullah 2")

console.log(message)

let num:number = 12
num = 10
num = 10.5

let city:string = "Sivas"
city = "İstanbul"
city = "Ankara"

let Istrue:boolean = true
Istrue = false
Istrue = true

let nums:number[] = [1,2,3]
let num2:Array<number> = [1,2,3]

//tuple
let array:[number,string] = [2,"Ankara"]
array[0]
array[1]

//enum
enum Color{Red=1,Black,Blue}
let color : Color = Color.Red

//any value type
let value : any = "İstanbul"
value = 2
value = {}

//value type
let value2 : void = undefined

function greeter2():void {
    console.log("Hello")
}

//undefined null
let age:number
//defined
age = 10

class Customer{}