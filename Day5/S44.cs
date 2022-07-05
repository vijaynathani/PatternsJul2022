//Keep things that vary separate from things that are constant.
public interface Resource {
    int getFree();
    void markFree(int r);
};
class File1 : Resource {
    public int getFree() {return 0;}
    public void markFree(int r){}
};
class Database1 : Resource {
    public int getFree() {return 0;}
    public void markFree(int r){}
}
public class ra2{
    public int allocate(Resource r) {
    	return r.getFree();
    }
    public void free(Resource r, int resourceId)  {
    	r.markFree(resourceId);
    }
}


