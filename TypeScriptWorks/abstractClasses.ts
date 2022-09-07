abstract class CreditBase {
    constructor() {

    }
    save():void{
        console.log("Saved")
    }

    abstract calculate():void;
}

class ConsumerCredit extends CreditBase {
    constructor() {
        super();
    }

    calculate(): void {
        console.log("Calculated for flat");
    }
}

class MortgageCredit extends CreditBase {
    constructor() {
        super();
    }

    calculate(): void {
        console.log("Calculated for mortgage credit");
    }

    anotherOperations(): void{

    }
}

let consumercredit = new ConsumerCredit();
consumercredit.calculate();
consumercredit.save();

let mortgageCredit = new MortgageCredit();
mortgageCredit.calculate();
mortgageCredit.save();

let credit : CreditBase
credit = new ConsumerCredit()

credit = new MortgageCredit()