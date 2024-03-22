using System.ComponentModel;
using System.Dynamic;

namespace Program;

public static class BookSorter
{
    public static string ReturnBooksStartingWithThe(List<Book> bookList)
    {
        string output = "";
        foreach(Book book in bookList)
        {
            if(book.title.Substring(0,4).ToUpper() == "THE ")
            {
                output += ", " + book.title;
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string ReturnBooksByAuthorWithTInName(List<Book> bookList)
    {
        string output = "";
        foreach(Book book in bookList)
        {
            if(book.author.Contains('('))
            {
                book.author = book.author.Substring(0,book.author.IndexOf('('));
            }
            if(book.author.Contains('t'))
            {
                output += ", " + book.title;
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string ReturnBooksWrittenAfterYear(List<Book> bookList, int year = 1992)
    {
        string output = "";
        foreach(Book book in bookList)
        {
            if(book.publication_year > year)
            {
                output += ", " + book.title;
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string ReturnBooksWrittenBeforeYear(List<Book> bookList, int year = 2004)
    {
        string output = "";
        foreach(Book book in bookList)
        {
            if(book.publication_year < year)
            {
                output += ", " + book.title;
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string ReturnISBNsFromSameAuthor(List<Book> bookList, string author)
    {
        string output = "";
        foreach(Book book in bookList)
        {
            if(book.author.ToUpper() == author.ToUpper())
            {
                output += ", " + book.isbn;
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string SortBooksAlphabetic(List<Book> bookList, bool ascending = true)
    {
        int bookAmount = bookList.Count;
        string[] toSort = new string[bookAmount];
        int counter = 0;
        foreach(Book book in bookList)
        {
            toSort[counter] = book.title;
            counter++;
        }

        Array.Sort(toSort);
        string output = "";
        if(ascending)
        {
            for(int i = 0; i < bookAmount; i++)
            {
                output += ", " + toSort[i];
            }
        }
        else
        {
            for(int i = bookAmount-1; i >= 0; i--)
            {
                output += ", " + toSort[i];
            }
        }
        output = output.Substring(2);
        return output;
    }
    public static string SortBooksChronological(List<Book> bookList, bool ascending = true)
    {
        int newestYear = 0;
        int oldestYear = 0;
        foreach(Book book in bookList)
        {
            if(newestYear == 0)
            {
                newestYear = book.publication_year;
                oldestYear = book.publication_year;
            }

            if(newestYear < book.publication_year)
            {
                newestYear = book.publication_year;
            }

            if(oldestYear > book.publication_year)
            {
                oldestYear = book.publication_year;
            }
        }

        string output = "";
        int year = oldestYear;
        while(year <= newestYear)
        {
            foreach(Book book in bookList)
            {
                if(book.publication_year == year)
                {
                    if(ascending)
                    {
                        output += ", " + book.title;
                    }
                    else
                    {
                        output = ", " + book.title + output;
                    }
                }
            }
            year++;
        }

        output = output.Substring(2);
        return output;
    }
    public static string GroupBooksByAuthorName(List<Book> bookList, bool lastName = true)
    {
        List<Author> authorList = new List<Author>();
        bool nullCatch = true;
        foreach(Book book in bookList)
        {
            if(nullCatch)
            {
                authorList.Add(new Author(book.author, book.title));
                nullCatch = false;
            }
            else
            {
                bool authorNotInList = true;
                foreach(Author author in authorList)
                {
                    if(lastName && book.author.Contains(author.LastName)
                        || !lastName && book.author.Contains(author.FirstName))
                    {
                        author.Bibliography.Add(book.title);
                        authorNotInList = false;
                    }
                }

                if(authorNotInList)
                {
                    authorList.Add(new Author(book.author, book.title));
                }
            }
        }
        
        string output = "";
        foreach(Author author in authorList)
        {
            if(lastName)
            {
                output += author.LastName + ": ";
            }
            else
            {
                output += author.FirstName + ": ";
            }
            foreach(string bookName in author.Bibliography)
            {
                output+= bookName + ", ";
            }
            output = output.Substring(0, output.Length-2);
            output += "\n";
        }
        
        return output;
    }
}

