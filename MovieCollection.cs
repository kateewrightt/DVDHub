// CAB301 - assignment 2
// An implementation of MovieCollection ADT
// 2023


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in the binary search tree 
public class BTreeNode
{
    private IMovie movie; // movie
    private BTreeNode? lchild; // reference to its left child 
    private BTreeNode? rchild; // reference to its right child

    public BTreeNode(IMovie movie)
    {
        this.movie = movie;
        lchild = null;
        rchild = null;
    }

    public IMovie Movie
    {
        get { return movie; }
        set { movie = value; }
    }

    public BTreeNode? LChild
    {
        get { return lchild; }
        set { lchild = value; }
    }

    public BTreeNode? RChild
    {
        get { return rchild; }
        set { rchild = value; }
    }
}

// invariant: no duplicate movie in this movie collection
public class MovieCollection : IMovieCollection
{
    private BTreeNode? root; // the root of the binary search tree in which movies are stored 
    private int count; // the number of movies currently stored in this movie collection 



    public int Number { get { return count; } }

    // constructor - create an empty movie collection
    public MovieCollection()
    {
        root = null;
        count = 0;
    }

    // Check if this movie collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this movie collection is empty; otherwise, return false. This movie collection remains unchanged and new Number = old Number
    public bool IsEmpty()
    {

        return root == null;

    }

    // Insert a movie into this movie collection
    // Pre-condition: nil
    // Post-condition: if the movie was not in this movie collection, the movie has been added into this movie collection, new Number = old Number + 1 and return true; otherwise, new Number = old Number and return false.
    public bool Insert(IMovie movie)
    {
        if (root == null && movie.Title != null)
        {
            root = new BTreeNode(movie);
            count++;
            return true;
        }
        else
            return Insert(movie, root);

    }
    private bool Insert(IMovie movie, BTreeNode ptr)
    {
        if (movie.Title == null)
        {
            return false;
        }
        int cmp = movie.Title.CompareTo(ptr.Movie.Title);
        if (cmp == 0)
        {
            return false;
        }
        else if (cmp < 0)
        {
            if (ptr.LChild == null)
            {
                ptr.LChild = new BTreeNode(movie);
                count++;
                return true;
            }
            else
            {
                return Insert(movie, ptr.LChild);
            }
        }
        else
        {
            if (ptr.RChild == null)
            {
                ptr.RChild = new BTreeNode(movie);
                count++;
                return true;
            }
            else
            {
                return Insert(movie, ptr.RChild);
            }
        }
    }



    // Delete a movie from this movie collection
    // Pre-condition: nil
    // Post-condition: if the movie was in this movie collection, the movie has been removed out of this movie collection, new Number - old Number - 1 and return true; otherwise, return false and this movie collection remains unchanged and new Number = old Number.
    public bool Delete(IMovie movie)
    {
        BTreeNode ptr = root;
        BTreeNode parent = null;
        while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
        {
            parent = ptr;
            if (movie.CompareTo(ptr.Movie) < 0)
                ptr = ptr.LChild;
            else
                ptr = ptr.RChild;
        }

        if (ptr != null)
        {
            if ((ptr.LChild != null) && (ptr.RChild != null))
            {
                if (ptr.LChild.RChild == null)
                {
                    ptr.Movie = ptr.LChild.Movie;
                    ptr.LChild = ptr.LChild.LChild;
                }
                else
                {
                    BTreeNode p = ptr.LChild;
                    BTreeNode pp = ptr;
                    while (p.RChild != null)
                    {
                        pp = p;
                        p = p.RChild;
                    }
                    ptr.Movie = p.Movie;
                    pp.RChild = p.LChild;
                }
            }
            else
            {
                BTreeNode c;
                if (ptr.LChild != null)
                    c = ptr.LChild;
                else
                    c = ptr.RChild;

                if (ptr == root)
                    root = c;
                else
                {
                    if (ptr == parent.LChild)
                        parent.LChild = c;
                    else
                        parent.RChild = c;
                }
            }
            count--;
            return true;

        }

        return false;

    }


    // Search for a movie by its title in this movie collection  
    // pre: nil
    // post: return the reference of the movie object if the movie is in this movie collection;
    //	     otherwise, return null. New Number = old Number.
    public IMovie? Search(string movietitle)
    {
        return Search(movietitle, root);
    }

    private IMovie? Search(string movietitle, BTreeNode r)
    {
        if (r != null)
        {
            if (movietitle.CompareTo(r.Movie.Title) == 0)
                return r.Movie;
            else if (movietitle.CompareTo(r.Movie.Title) < 0)
                return Search(movietitle, r.LChild);
            else
                return Search(movietitle, r.RChild);
        }
        else
            return null;
    }


    // Calculate the total number of DVDs in this movie collection 
    // Pre-condition: nil
    // Post-condition: return the total number of DVDs in this movie collection. this moive collection remains unchanged, and new Number = old Number.
    public int NoDVDs()
    {
        int total = 0;

        if (root != null)
        {
            void InOrderTraversal(BTreeNode node)
            {
                if (node != null)
                {
                    InOrderTraversal(node.LChild);
                    total += node.Movie.TotalCopies;
                    InOrderTraversal(node.RChild);
                }
            }
            InOrderTraversal(root);
        }
        
        return total;
    }



    // Return an array that contains all the movies in this movie collection and the movies in the array are sorted in the dictionary order by movie title
    // Pre-condition: nil
    // Post-condition: return an array of movies that are stored in dictionary order by their titles, this movie collection remains unchanged and new Number = old Number.
    public IMovie[] ToArray()
    {
        IMovie[] movies = new IMovie[count];
        int index = 0;


        void InOrderTraversal(BTreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.LChild);
                movies[index] = node.Movie;
                index++;
                InOrderTraversal(node.RChild);
            }
        }

        InOrderTraversal(root);
        return movies;
    }

    // Clear this movie collection
    // Pre-condotion: nil
    // Post-condition: all the movies in this movie collection have been removed from this movie collection and new Number = 0. 
    public void Clear()
    {

        root = null;
        count = 0;

    }
}





