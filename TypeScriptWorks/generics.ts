function values(x:number):number{
    return x;
}

let num = values(10)
console.log(num)

function values2(x:string):string{
    return x;
}

let city = values2('İstanbul')
console.log(city)

function values3<T>(x:T):T{
    return x;
}

let num3 = values3<number>(3)
let city3 = values3<string>("İstanbul")

console.log(num3 + ' ' + city3)