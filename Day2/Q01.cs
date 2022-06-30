//Improve the code
class Order {
    //...
    bool IsSameString(string s1, string s2){
        if(s1==s2) return true;
        if(s1==null) return false;
        return (s1.Equals(s2));
    }
}
class Mail {
    //...
    static bool IsSameString(string s1, string s2) {
        if (s1 == s2)
            return true;
        if (s1 == null)
            return false;
        return (s1.Equals(s2));
    }
}
