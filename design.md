# Project Design

### Purpose
The purpose of the LOTR_SDK project is to provide a convenient way to interact with the [LOTR API](https://the-one-api.dev/documentation). This SDK aims to simplify the integration of LOTR API functionality. This has been turned into a NuGet package that can be found with the Package ID "[Sal-ImpastatoLOTR-SDK](https://www.nuget.org/packages/Sal-ImpastatoLOTR-SDK)".

## Architecture
### Classes
| Class | Function |
| ------ | ------ |
| Setup | This class is used to assign the users access token, and set the path for their log.txt file.|
| Movies | The Movies class is one of two main classes the user will be using to access the API. |
| Quote | The Quote class is the other primary class the user will be utilizing to interact with the API. |
| Utilities | This class is initiated by the Call method in both the Movies and Quote classes and sets up the API request based on the parameters set in the users request. |
| CallToLotrAPI |The CallToLotrAPI takes the info from the .Call methods and the Utilities class and makes and logs all API requests and responses.|
| EndPoints | This is a list of endpoints and options for querying the API. |


## #Core Classes 
The core usage of this SDK is in utilizing two calls methods in the Movies and Quote classes. 
- Movies.Call
- Quote.Call

Both methods contain all the default variables necessary to allow a requested without passing any parameters. They can also be used to isolate any additional parameters to scope into the exact data the user requires from the API. Each call method is formatting the request and reaching out to the API via two helper classes. 

## Parameters used by both of the primary user methods above.
	quotes (optional): This is only available for Movie.Call, A boolean flag indicating whether to include quotes associated with the movie (default: false).
	pageSelection (optional): The page number to retrieve when paginating through the results (default: 1).
	limitAmount (optional): The maximum number of results to return per page (default: 50).
	offSet (optional): The offset value for paginated results (default: 0).
	sortBy (optional): The field to use for sorting the results (default: null).
	sortOrder (optional): The order in which to sort the results (asc for ascending, desc for descending) (default: null).
	match (optional): A query parameter for matching specific fields in the request (default: null).
	include (optional): A query parameter for including additional related data in the response (default: null).
	exists (optional): A query parameter for checking if specific fields exist in the request (default: null).
	regex (optional): A query parameter for performing regular expression-based matching on specific fields (default: null).
	greaterLessThanEqual (optional): A query parameter for performing greater than, less than, or equal comparisons on specific fields (default: null).

### Helper Classes
These classes facilitate the building of the API request, logging, filtering, sorting, and Pagination. The Setup class is only used to update the Access Token, or assing the path for the log.txt file.
- Utilites
- CallToLotrAPI
- Setup

###Variable storage
Each of these classes are used to store and refrence date for the project. 
- Autentication
- Endpoints

# Key Design Decisions
- Modularity: The project is designed to be modular and extensible. Each component has a specific responsibility and can be easily maintained, updated, or replaced without affecting the rest of the project.

- Error Handling: The project includes API logging to help the user identify any issues they may run into when making request. With a setup method in place to ease the process. API responses and errors are appropriately processed and logged into the log.txt file. This ensuring that user will have access to records off all error messages to occur.
