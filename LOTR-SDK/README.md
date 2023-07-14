# Lord of the Rings SDK

This is the LOTR-SDK a more convenient way to interact with the LOTR API(https://the-one-api.dev/documentation), allowing you to retrieve information about movies & quotes from the Lord of the Rings universe.

GETTNIG SETUP:
First install the LOTR SDK NuGet into your project by following these steps:
	Create a new C# project in Visual Studio 
	Right-click on your project in the Solution Explorer and select "Manage NuGet Packages" from the context menu.
	In the NuGet Package Manager window, click on the "Browse" tab.
	Search for the NuGet package in the search box titled SalvadorImpastatoLOTR-SDK.1.0.0.
	Select the package from the search results.
	On the right-hand side, check the checkbox next to your project name to include the package in your project.
	Click on the "Install" button to install the selected package. Visual Studio will now download and add the LOTR-SDK NuGet package as a dependency in your project. The package and its dependencies will be downloaded and restored to your project's packages folder.
	

Next request an LOTR API access token from here: (https://the-one-api.dev/sign-up)


Import the LOTR_SDK namespace in your C# code files:"using LOTR_SDK;"


Set up your API key by running the following method passing in your LOTR access token.
	Setup.SetAPIKey("Access Token");


This is optional, but recommend for logging, set the log file path for debugging. This can be in the same directory as the project, and will create a log.txt file to store all API request, responses, and errors.
	Setup.SetLogFilePath("LOG_FILE_PATH");

USAGE:
If you have your log file set up you can see all of the reponses from the methods there, or you can output them to console for testing. 

-----Movie API Request Methods - These can be ues to query information on the LOTR movies.-----
            /// Full list of variables you can pass to the Movie.Call method
            /// (string movieId, bool quotes, int pageSelection, int limitAmount, int offSet, string sortBy, string sortOrder, string match, string include, string exists, string[] regex = null, string greaterLessThanEqual)


Parameters
	movieId (optional): The ID of the movie to retrieve information for. If not provided, information about all movies will be returned.
	quotes (optional): A boolean flag indicating whether to include quotes associated with the movie (default: false).
	pageSelection (optional): The page number to retrieve when paginating through the results (default: 1).
	limitAmount (optional): The maximum number of results to return per page (default: 50).
	offSet (optional): The offset value for paginated results (default: 0).
	sortBy (optional): The field to use for sorting the results.
	sortOrder (optional): The order in which to sort the results (asc for ascending, desc for descending).
	match (optional): A query parameter for matching specific fields in the movie data.
	include (optional): A query parameter for including additional related data in the response.
	exists (optional): A query parameter for checking if specific fields exist in the movie data.
	regex (optional): A query parameter for performing regular expression-based matching on specific fields.
	greaterLessThanEqual (optional): A query parameter for performing greater than, less than, or equal comparisons on specific fields.

---------------------------------------------Example calls:-----------------------------------------------------

Default Movie.Call method.
	await Movie.Call();

Search movie by Id.
	await Movie.Call("5cd95395de30eff6ebccde5d");

Call the Movie method for all quotes by selected movie.
	await Movie.Call("5cd95395de30eff6ebccde5c", true);

Movie by ID displaying all quotes with page and limit specified.
	await Movie.Call("5cd95395de30eff6ebccde5c", true, 55, 3);

Movie with ID by page, lmit, sort by name, and sort order by decending.
	await Movie.Call("5cd95395de30eff6ebccde5c", true, 2, 5, "name", "dec");

Movies returned with matching fields of name.
	await Movie.Call(match: "name=The Return of the King"); 	// Name matches "The Return of the King"
	await Movie.Call(match: "name!=The Return of the King");	// Name does not match "The Return of the King"

Sorting movie or quote calls with the regex parameter.
            //await Movie.Call(regex: "name,tower"); 	// Name with tower it
            //await Movie.Call(regex: "name!,tower");	// Names without tower in it

Movie with page specified and all movies with budgetInMillions < 100.
            //reponseBody = await Movie.Call(pageSelection: 1, greaterLessThanEqual: "budgetInMillions<100");

MoAll movies with runTimeInMinutes >= 160.
            //reponseBody = await Movie.Call(greaterLessThanEqual: "runtimeInMinutes>=160");



-----Quote API Request Methods - These can be ues to query information on quotes from the LOTR.----- 
            /// Full list of variables you can pass to the Quote.Call method
            /// (string quoteId, int pageSelection, int limitAmount, int offSet, string sortBy, string sortOrder, string match, string include, string exists, string[] regex = null, string greaterLessThanEqual)


Parameters
	quoteId (optional): The ID of the quote to retrieve information for. If not provided, information about all quotes will be returned.
	pageSelection (optional): The page number to retrieve when paginating through the results (default: 1).
	limitAmount (optional): The maximum number of results to return per page (default: 50).
	offSet (optional): The offset value for paginated results (default: 0).
	sortBy (optional): The field to use for sorting the results.
	sortOrder (optional): The order in which to sort the results (asc for ascending, desc for descending).
	match (optional): A query parameter for matching specific fields in the movie data.
	include (optional): A query parameter for including additional related data in the response.
	exists (optional): A query parameter for checking if specific fields exist in the movie data.
	regex (optional): A query parameter for performing regular expression-based matching on specific fields.
	greaterLessThanEqual (optional): A query parameter for performing greater than, less than, or equal comparisons on specific fields.

---------------------------------------------Example calls:-----------------------------------------------------

Default Quote.Call method.
	await Quote.Call();

Call the quote endpoint quote ID.
	await Quote.Call("5cd96e05de30eff6ebcce7e9");

A call that utilizes the Match and negate match parameter. 
	await Quote.Call(match: "dialog!=Deagol!"); 	// Returns all dialog that is not "Deagol!" 
	await Quote.Call(match: "dialog=Deagol!"); 	// Returns all dialog that is "Deagol!" 

Exist or doesn't exist. This varialbe will return if the designated variable is present or not.
	await Quote.Call(exists: "!name");
	await Quote.Call(exists: "name")

Quote.call using Include and Exclude
	await Quote.Call(include: "dialog=Deagol!"); 	//Include quotes with Deagol! int it
	await Quote.Call(include: "dialog!=Deagol!");	//Exclude quotes with Deagol! int it

Quote with page specified and sorted by name in acending order
	await Quote.Call(pageSelection: 2, sortBy: "name", sortOrder: "asc");



