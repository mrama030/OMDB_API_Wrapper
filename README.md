# OMDB_API_Wrapper

### Current Release: Version 1.0.0

### Description
TODO

### Technical Information
- Download the NuGet Package here: https://github.com/mrama030/OMDB_API_Wrapper/tree/master/OMDB_API_Wrapper/OMDB_API_Wrapper/bin/Debug/OMDB_API_Wrapper.1.0.0.nupkg

- Download the DLL library here: https://github.com/mrama030/OMDB_API_Wrapper/tree/master/OMDB_API_Wrapper/OMDB_API_Wrapper/bin/Debug/netstandard2.0/OMDB_API_Wrapper.dll

- All OmdbClient public methods are **asynchronous** by default, but can be run **synchronously** using the following syntax:
```cs
var x = MethodName([...parameters...]).GetAwaiter().GetResult();
```

### Response types for each request type 
| Request Type  | Response Type |
| ------------- | ------------- |
| ByTitleRequest  | ByTitleResponse  |
| ByIDRequest  | ByTitleResponse  |
| BySearchRequest  | BySearchResponse |

## Instructions for By-Title Requests
TODO

## Instructions for By-ID Requests
TODO

## Instructions for By-Title Requests
TODO
