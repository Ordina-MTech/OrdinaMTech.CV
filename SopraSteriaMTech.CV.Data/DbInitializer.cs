namespace SopraSteriaMTech.Cv.Data;

public static class DbInitializer
{
    public static void Initialize(CvContext context)
    {
        context.Database.EnsureCreated();
    }
}