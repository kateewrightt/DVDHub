using System;

class Program
{
    static void Main(string[] args)
    {
        IMovieCollection Movies = new MovieCollection();
        IMovie movie1 = new Movie("Interstellar", MovieGenre.Action, MovieClassification.M15Plus, 60, 4);
        IMovie movie2 = new Movie("Psycho", MovieGenre.Action, MovieClassification.M15Plus, 109, 3);
        IMovie movie3 = new Movie("Alien", MovieGenre.Action, MovieClassification.M15Plus, 117, 2);
        IMovie movie4 = new Movie("Rocky", MovieGenre.Drama, MovieClassification.PG, 120, 5);
        IMovie movie5 = new Movie("Avatar", MovieGenre.Action, MovieClassification.M15Plus, 162, 3);
        IMovie movie6 = new Movie("Bolt", MovieGenre.Comedy, MovieClassification.G, 96, 6);
        IMovie movie7 = new Movie("Coco", MovieGenre.Comedy, MovieClassification.G, 105, 4);
        IMovie movie8 = new Movie("Jaws", MovieGenre.Drama, MovieClassification.M15Plus, 124, 2);

        Movies.Insert(movie1);
        Movies.Insert(movie2);
        Movies.Insert(movie3);
        Movies.Insert(movie4);
        Movies.Insert(movie5);
        Movies.Insert(movie6);
        Movies.Insert(movie7);
        Movies.Insert(movie8);

        Console.WriteLine("====================================================================================================");
        Console.WriteLine(" Movie Collection Overview");
        Console.WriteLine("===================================================================================================="); Console.WriteLine();
        Movies.PrettyPrint(1, 1);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("====================================================================================================");
        Console.WriteLine(" Movie Details");
        Console.WriteLine("====================================================================================================");
        IMovie[] movies = Movies.ToArray();
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"[{i + 1}] Title: {movies[i].Title}, Genre: {movies[i].Genre}, " +
                $"Classification: {movies[i].Classification}, Duration: {movies[i].Duration}, " +
                $"Available Copies: {movies[i].AvailableCopies}");
        }
    }

    
}
