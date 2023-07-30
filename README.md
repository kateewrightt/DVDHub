# DVD Hub
Simplifying Movie Library Management with Efficiency

## Overview
This Reusable Movie Library Management System is a user-friendly project that 
transforms the way movie DVDs are handled in libraries. This efficient system 
optimizes movie DVD management, making it easy for users to find and borrow 
their favorite movies hassle-free.

## How to Use

1.  Clone the repository to your local machine.
2.  Navigate to the project directory.
3.  Launch the DVDHub application using a C# development environment (e.g. Visual Studio).
4.  Use the Program.cs file to modify the Movie Database.

## Features
- **Add Movies**: Easily add new movies to your collection using Movies.Insert(movie).
- **Remove Movies**: Remove movies you no longer want in your collection using Movies.Delete(movie).
- **Find Movies**: Search for movies by their titles to get their details using Movies.Search(movieTitle).
- **Compare Movies**: Compare movies in your collection based on their titles using movie1.Compareto(movie2).
- **Movie Details**: Access movie details using Movie.ToString().
- **Check Empty Collection**: Quickly check if the movie collection is empty using Movies.IsEmpty().
- **Total DVDs**: Get the total number of DVDs in your collection with Movies.NoDVDs().
- **Movie Array**: Obtain an alphabetically sorted array of all movies in your collection using Movies.ToArray().

## Movie Details Format
The Movie Class requires: Title, Genre, Classification, Duration, Available Copies

~~~
IMovie movie1 = new Movie("Interstellar", MovieGenre.Action, MovieClassification.M15Plus, 60, 4);
~~~
