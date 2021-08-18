# Zemoga .net Test

This is my implementation of the .net test.

## Set up

I used Visual Studio Community 2019 for creating the solution.

Web API was created using .net Core 3.1.

Frontend was created using Angular v8. (Template provided by VS)

Entityframework as ORM using InMemory Database.

JWT to secure the Endpoints

## Usage

You can go to http://localhost:35296/swagger/index.html to see the swagger page with the endpoints.

This is the main route http://localhost:35296/, after you go to that URL, you'll be redirected to the login page, there you can find a note with the different users you can use (Users are created in memory database automatically).

- For Public role you have just 2 tabs (Published Post and logout)
- For Writer role you have 4 tabs (Published , My Posts, New Post and logout)
- For Editor role you have 3 tabs (Published , Pending for approval and logout)

## Time Spent On The Test
I spent approximately 14 hours.


## Things To Improve
- Frontend validations and UI/Design.
- Exceptions handling.
- Implement some logs for the API.
- Add unit tests.