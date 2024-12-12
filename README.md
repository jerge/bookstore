# Bookstore


## Startup

docker compose up

Start IIS Express via visual studio


To reset the database, perform:

docker compose down --volumes


// TODO
```
dotnet publish -c Release -o out

docker build -t bookstore:latest .


```

## Usage (postman)

To use the application. Start by starting it as seen in *Startup*.

When the application is running import the postman collection in the `postman` directory.

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