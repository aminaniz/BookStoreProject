export class coupon {
    constructor(
        public CouponId ?:number,
        public Tag ?:string,
        public Discount ?:number ,
        public ExpiryDate ?:Date,
        public MinAmount?: number,
        public Activated ?:number
        
    ){}
   
    
}