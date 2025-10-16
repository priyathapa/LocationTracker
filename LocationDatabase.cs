using SQLite;

namespace LocationTracker.Data;

public class LocationDatabase
{
	private readonly SQLiteAsyncConnection _database;

	public LocationDatabase(string dbPath)
	{
		//create database connection to SQLite database
		_database = new SQLiteAsyncConnection(dbPath);

		//create table if it doesn't exist already
		_database.CreateTableAsync<LocationEntry>().Wait();
	}

	// Insert a new location entry
	public Task<int> SaveLocationAsync(LocationEntry location) =>
		_database.InsertAsync(location);


	// Get all location entries
	public Task<List<LocationEntry>> GetLocationsAsync() =>
		_database.Table<LocationEntry>().ToListAsync();

	// Delete a location entry
	public Task<int> DeleteLocationAsync(LocationEntry location) =>
	_database.DeleteAsync(location);

}
