# BookMyShow
```
Framework - .Net Core

Language  - C#

Database  - SQL Server

ORM       - Entity Framework
```

API's

1. Register User
Post - https://localhost:44319/api/User

Body - 
```json
{
		  "userName": "vipul",
		  "password": "12345678"
}
```
	
> Right now user has only 2 fields Username (unique) and password 
> Storing password in plain text for demo 
> No password complexity rule
====================================================================
2. Login

Post - https://localhost:44319/api/User/login
Body - 
```json
{
		  "userName": "vipul",
		  "password": "12345678"
}
```

Result Token  (does not validate authorization only validate authentication)
=====================================================================
3. Get Movies running in perticular city

Get - https://localhost:44319/api/Movie/cityId?cityId=1

Result - 
```json
[ 
	{
		"movieId":1,
		"title":"Movie 1 Title", 
		"description":"Movie 2 Desc",
		"releaseDate":"2021-10-03T16:16:31.3383142" 
	}, 
	{
		"movieId":2,
		"title":"Movie 2 Title", 
		"description":"Movie 3 Desc",
		"releaseDate":"2021-08-24T16:16:32.4964161"
	} 
]
```
================================================================

4. Get Cinemas Running Perticular movieId
Get - https://localhost:44319/api/Movie/movieId?movieId=1

Result - 
```json
[
  {
    "cinemaId": 1,
    "name": "Cinema1",
    "cinemaHalls": [
      {
        "cinemaHallId": 1,
        "name": "Cinema 1 Hall 1",
        "shows": [
          {
            "date": "2021-11-23T16:16:32.6040112",
            "startTime": "2021-11-23T16:16:32.6040124",
            "endTime": "2021-11-23T18:16:32.6040125"
          },
          {
            "date": "2021-11-23T16:16:32.6238144",
            "startTime": "2021-11-23T19:16:32.6238161",
            "endTime": "2021-11-23T21:16:32.6238163"
          }
        ]
      }
    ]
  }
]
```
========================================================================

5. Booking

Post - https://localhost:44319/api/Booking

Body -
```json
{
  "showId": 1,
  "cinemaHallSeatId": 1,
  "userName": "vipul",
  "token": "AlAohKyt2UiutK9XFs58TIhBfDnxLp8V"
}
```
Result - 
200 - Booking ID
400 - AlreadyBooked , Any other validation


==========================================================================

DB

![image](https://user-images.githubusercontent.com/25218865/142856501-05a60c2c-dec9-4e4e-8176-619c84629df6.png)


```
Upgrade Pending
> JWT token authentication
> Password encryption
> Multi Seat booking
```
