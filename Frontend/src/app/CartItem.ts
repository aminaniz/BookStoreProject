export class CartItem{

    constructor(
        public CartItem_Id?:number,
        public BookId?:number,
        public UserId?:number,
        public Price?:number,
        public Quantity?:number,
        public Active?:number,
        public Total?:number

    ){}
}