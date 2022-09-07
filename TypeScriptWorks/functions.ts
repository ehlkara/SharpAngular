function sum(x,y){
    return x+y;
}

function sum2(x:number,y:number):number{
    return x+y;
}

let sum3 = function(x:number,y:number):number{
    return x+y;
}

console.log(sum(2,3));
console.log(sum("İstnabul",2));
console.log(sum2(2,4));
console.log(sum3(4,8));

function sum4(x:number,y:number = 4):number{
    return x+y;
}

console.log(sum4(3));


function sum5(x:number,y?:number):number{
    if(y) {
        return x+y;
    }
    return x;
}

console.log(sum5(3,40));