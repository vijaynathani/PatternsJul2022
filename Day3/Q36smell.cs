//Improve the code
class Currency {
    public const int USD=0;
    public const int RMB=1; //Chinese currency
    public const int ESCUDO=2; //Portuguese currency
    private int currencyCode;
    public Currency(int currencyCode) {
        this.currencyCode=currencyCode;
    }
    public string format(int amount) {
        switch (currencyCode) {
        case USD:
            //return something like $1,200
			break;
        case RMB:
            //return something like RMB1,200
			break;
        case ESCUDO:
            //return something like $1.200
			break;
        }
		return  ...;
    }
}
