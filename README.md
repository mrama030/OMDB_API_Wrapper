# OMDB_API_Wrapper

### Current Release: Version 1.1.2

### Description
An easy-to-use API wrapper/client for the Open Movie Database / OMDB API, which can be used in any .NET project. Available as a DLL library and a NuGet package. This library focuses on being easy to understand, simple to use and offer full coverage of features offered by the OMDB API. Terminology used by this library is strongly associated to the official OMDB API documentation found online at http://www.omdbapi.com/

### Download Links
- Download the NuGet Package here: https://github.com/mrama030/OMDB_API_Wrapper/tree/master/OMDB_API_Wrapper/OMDB_API_Wrapper/bin/Debug/OMDB_API_Wrapper.1.1.0.nupkg

- Download the DLL library here: https://github.com/mrama030/OMDB_API_Wrapper/tree/master/OMDB_API_Wrapper/OMDB_API_Wrapper/bin/Debug/netstandard2.0/OMDB_API_Wrapper.dll

## How to use?
All OMDB_API_Wrapper public classes and public methods available for use by developers have been XML-documented. This means you may access this documentation through your IDE (i.e. hover over method or class) or read it directly within the source code in this GitHub repository. Examples below should also be referenced.

### Summary of Response Types Generated for each Request Type 
| Request Type  | Response Type |
| ------------- | ------------- |
| ByTitleRequest  | ByTitleResponse  |
| ByIDRequest  | ByTitleResponse  |
| BySearchRequest  | BySearchResponse |

### Examples (C#)

#### OMDB API Client Creation
```cs
OmdbClient omdbClient = new OmdbClient("YOUR_API_KEY");
```

#### API Key Validation 
```cs
// Asynchronous
bool isKeyValidAsync = await omdbClient.IsAPIKeyValidAsync();

// Synchronous
bool isKeyValidSync = omdbClient.IsAPIKeyValidSync();
```

#### ByTitleRequest Creation
```cs
// Basic - No optional parameters - Short plot
ByTitleRequest byTitleRequestBasic = new ByTitleRequest("rick and morty");

// Detailed - With optional parameters - Full plot
ByTitleRequest byTitleRequestDetailed = new ByTitleRequest("rick and morty", VideoType.Series, null, PlotSize.Full);
```

#### ByTitleRequest Execution
```cs
// Asynchronous 
ByTitleResponse byTitleResponseAsync = await omdbClient.ByTitleRequestAsync(byTitleRequestBasic);

// Synchronous 
ByTitleResponse byTitleResponseSync = omdbClient.ByTitleRequestSync(byTitleRequestBasic);
```

#### ByIDRequest Creation
```cs
// Short plot
ByIDRequest byIDRequestShortPlot = new ByIDRequest("tt1219827");

// Full plot
ByIDRequest byIDRequestFullPlot = new ByIDRequest("tt1219827", PlotSize.Full);
```

#### ByIDRequest Execution (Responses are ByTitleResponse objects)
```cs
// Asynchronous 
ByTitleResponse byIDResponseAsync = await omdbClient.ByIDRequestAsync(byIDRequestShortPlot);

// Synchronous 
ByTitleResponse byIDResponseSync = omdbClient.ByIDRequestSync(byIDRequestShortPlot);
```

#### BySearchRequest Creation
```cs
// All Results - No optional parameters
BySearchRequest bySearchRequestAll = new BySearchRequest("ghost in the shell");

// Page 2 Only (Results 11 to 20 only) - No optional parameters
BySearchRequest bySearchRequestPageSpecific = new BySearchRequest("ghost in the shell", null, null, 2);

// All Results - With optional parameters
BySearchRequest bySearchRequestFiltered = new BySearchRequest("ghost in the shell", VideoType.Movie, 2017);
```

#### BySearchRequest Execution
```cs
// Asynchronous 
BySearchResponse bySearchResponseAsync = await omdbClient.BySearchRequestAsync(bySearchRequestAll);

// Synchronous 
BySearchResponse bySearchResponseSync = omdbClient.BySearchRequestSync(bySearchRequestAll);
```
