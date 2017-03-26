namespace SoftStore.Data
{
    public class Data
    {
        private static SoftStoreContext context;

        public static SoftStoreContext Context => 
            context ?? (context = new SoftStoreContext());
    }
}
