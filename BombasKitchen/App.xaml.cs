using BombasKitchen.Data;

namespace BombasKitchen;

public partial class App : Application
{
    private static Database database;
    public static Database Database
    {
        get
        {
            if (database == null)
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "kitchen.db3"));
            else
                RunMigrations();

            return database;
        }
    }

    public static void RunMigrations()
    {
        //database.ClearTableProduct();
    }

    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }
}
