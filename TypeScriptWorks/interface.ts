interface Product{
    id:number;
    name:string;
    unitPrice:number;
}

function save(product:Product){
    console.log(product.name + " saved!")
}

save({id:1,name:"Pen",unitPrice:20});

class Product2{
    id:number;
    name:string;
    unitPrice:number;
}

let mouse = new Product2();
mouse.name = "Atech"

function save2(product2:Product2){
    console.log(product2.name + " saved!")
}

save2(mouse);

interface IPersonService{
    save();
}

class CustomerService implements IPersonService{
    save() {
    }
    
}