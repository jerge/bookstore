# Bookstore


## Startup Locally

To start the database only run:

```
docker compose up postgres
```

Then start the program in visual studio with the IIS Express profile

NOTE: This requires you to have postgres setup in your hosts file to point to localhost. You may also edit the appsettings.json connection string to refer to localhost instead of postgres.

## Startup within docker

Publish the application (only required if you've made edits)

```
dotnet publish -c Release -o out
```

Start the program and the database with:

```
docker compose up
```

Then the application is running on port 8080. Feel free to call it with the postman requests.

To exit press CTRL + C or perform:

```
docker compose down
```

The database is saved between runs. To remove the volume, run:

```
docker compose down --volumes
```

## Usage (postman)

To use the application. Start by starting it as seen in *Startup within docker*.

When the application is running import the postman collection in the `postman` directory. Use the IIS Express collection if you are running C# in Visual Studio instead of the docker container

In it there exists 5 requests, one per endpoint.

- The first request GET All will fetch all books
- The second request GET By Id will fetch a specific book based on the id in the query. Feel free to edit the query to fetch different books.
- The third request POST Create will create a new book with an already specified `id` and `title` in the raw body in JSON format. Feel free to edit either of those. Note that if you try to create a book with the same id multiple times it will return an error.
- The fourth request DELETE Delete will remove a specific book by the id in the query. The one saved in the collection contains the id of the book created in step 3, so first run that create step to test the deletion.
- The fifth request PUT Update by id will edit the title of an existing book based on the id in the query and the new title entered in the header. This specific case will edit one of the seeded books. Feel free to test other ids and titles.

An example scenario that utilizes all endpoints is:

- Run first request to GET ALL existing books
- Run third request to Create a new book
- Run the seconds request with the new book's id to check if it exists as you expected
- Run the fourth request to delete it
- Run the first request to see that there no longer exists a book like the one you created.
- Run the fifth request to update the book "Return Of The King" so it is "Lord of the Rings: The Return of the King".

## Possible improvements

Consider utilizing multiple appsettings.json files to make it easier to switch for example host in the database connection string.

Consider moving more functionality to the startup.cs file instead of having it in program.cs

Consider utilizing Dtos for all books incoming/outgoing from endpoints.

Consider creating database constraints on id and titles

Consider ensuring consistent output structure from endpoints (e.g. validation errors use the same information model as database conflicts)

Consider adding more error handling. (For example try catches in database operations)

Consider fleshing out the swagger documentation
