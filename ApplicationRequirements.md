# BookShelf Application

**High level**

As a user, I want to have an application where I can store the books I have, and later to get a list of them.

**Details**

For achieving this Story, a Web API should be created using .Net.

This Web API should have endpoints to manage the books and endpoints to create and list Authors, that after created can be associated with a specific book.

The Web API can list the authors and books without a user logged, but only logged users can create, modify and delete data.

**Endpoints**

For books:
  * Get all books
  * Get a book based on its id
  * Create a book
  * Update a book
  * Delete a book 

For authors:
  * Get all authors
  * Get an author by its id
  * Get the authors for a book, based on the book id
  * Create a author
