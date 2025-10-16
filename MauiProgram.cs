using LocationTracker;
using LocationTracker.Data;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

		//create the app builder
		var builder = MauiApp.CreateBuilder();

		//configure the app
		builder
			.UseMauiApp<App>() //specify the main application class
			.UseMauiMaps() //enable map functionality
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); //add custom font
			});

		// define path for the local SQLite database
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "locations.db3");

		//register the LocationDatabase as a singleton service
		builder.Services.AddSingleton(new LocationDatabase(dbPath));

		return builder.Build();
	}

}
