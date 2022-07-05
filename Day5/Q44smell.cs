//We need exclusive access to FILE1 and DATABASE1.
//New resources will be added later on. The design should be able
//accomodate these new resource allocation/deallocation easily.
public enum ResourceType { FILE1, DATABASE1 }
public class ra1{
    public int allocate(ResourceType r) {
        int resourceId = 0;
        switch (r) {
        case ResourceType.FILE1:
            resourceId = getFreeFile();
            break;
        case ResourceType.DATABASE1:
            resourceId = getFreeDatabase();
			break;
        }
        return resourceId;
    }

    public void free(ResourceType r, int resourceId)  {
        switch (r) {
        case ResourceType.FILE1:
            markFileFree(resourceId);
            break;
        case ResourceType.DATABASE1:
            markDatabaseFree(resourceId);
			break;
        }
    }
    private void markDatabaseFree(int a){}
    private void markFileFree(int a) {}
    private int getFreeFile() {return 0;}
    private int getFreeDatabase() {return 0;}
}
