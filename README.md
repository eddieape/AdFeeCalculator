# AdFeeCalculator

This is a Web application based on ASP.NET Core with Angular. The project is responsible for calculating the price of the ad based on its length and type.

## Development Environment

- Step1: Install Visual Studio 2019
- Step2: Install Node.js

## Complie and Run the project

- Download the whole project;
- Run Visual Studio 2019
- Open the project file named "AdFeeCalculator.sln" in Visual Studio 2019
- Build and run the project in Visual Studio 2019;

## Assumptions

- According to one of the acceptance criteria, that is the time length entered can be no longer than 5 minutes, I assume that after 180 seconds, the charge is $0.75/sec.
- For one of the non-functional requirements, that is external developers want to be able to create their own UI’s, I designe two Rest APIs, one is responsible for getting ad parameters, the other is responsible for calculating the ad fee. The detail see the following:

  - GET /api/adpricing

    Returns the all ad parameter objects. For example:

     ```
     {
        "adTimeLenRange": {
            "maxSecs": 300,
            "minSecs": 5
        },
        "mediaTypes": [
            "Video",
            "Radio"
        ],
        "stations": [
            "Star Wars FM",
            "Plainsmen FM",
            "Other"
        ]
    }
    ```

  - POST /api/adpricing

    Returns the price of an ad based on its length and type. For example:

    ```
    Request body:
    --------------------------------
    {
        "AdTimeLen": 5,
        "MediaType":"Radio",
        "Stations":["Star Wars FM", "Plainsmen FM"]
    }
    ```

    ```
    Response
    --------------------------------
    {
        "totalFee": 1275,
        "status": 0,
        "error": ""
    }
    ```

    If the return value of status is 0, this mean the operation is successful Otherwise, if its value is -1, it means that there is an error occurred. For example:

    ```
    Request body:
    --------------------------------
    {
        "AdTimeLen": 4,
        "MediaType":"Radio",
        "Stations":["Star Wars FM", "Plainsmen FM"]
    }
    ```

    ```
    Response
    --------------------------------
    {
    "totalFee": 0,
    "status": -1,
    "error": "The value of AdTimeLen must be between 5s and 300s."
    }
    ```
