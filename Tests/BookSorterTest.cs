namespace Tests;

using System.Text.Json;
using System.Text.Json.Serialization;
using Program;
public static class BookSorterTest
{
    public static List<Book> CreateBookList()
    {
        FileStream stream = File.OpenRead(Path.GetFullPath(@"Data\booklist.json"));
        List<Book> bookList = JsonSerializer.Deserialize<List<Book>>(stream);
        stream.Close();
        return bookList;
    }
    [Fact]
    public static void BookSorter_ReturnBooksStartingWithThe_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.ReturnBooksStartingWithThe(bookList);


        Assert.Equal("The", result.Substring(0,3));
    }
    [Fact]
    public static void BookSorter_ReturnBooksByAuthorWithTInName_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.ReturnBooksByAuthorWithTInName(bookList);
        string expected ="Snuff, The Colour of Magic";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_ReturnBooksWrittenAfterYear_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.ReturnBooksWrittenAfterYear(bookList);
        string expected = "Meditations: A New Translation, Snuff, The Collapsing Empire, The Art of War: A New Translation";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_ReturnBooksWrittenBeforeYear_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.ReturnBooksWrittenBeforeYear(bookList);
        string expected = "Meditations: A New Translation, The Colour of Magic, Thief of Time";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_ReturnISBNsFromSameAuthor_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.ReturnISBNsFromSameAuthor(bookList, "Neil Gaiman");
        string expected = "0-06-225565-7, 0-06-222407-7, 0-06-051518-X";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_SortBooksAlphabetic_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.SortBooksAlphabetic(bookList,ascending: false);
        string expected = "Zoe's Tale, Wyrd Sisters, Words of Radiance";
        
        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_SortBooksChronological_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.SortBooksChronological(bookList, ascending: false);
        string expected = "King Bullet, Cytonic, Rhythm of War";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
    [Fact]
    public static void BookSorter_GroupBooksByAuthorName_ReturnString()
    {
        List<Book> bookList = CreateBookList();

        string result = BookSorter.GroupBooksByAuthorName(bookList, lastName: false);
        string expected = "Marcus: Meditations: A New Translation\nTerry: Snuff, The Colour of Magic, Thief of Time, Reaper Man, Hogfather,";

        Assert.Equal(expected, result.Substring(0,expected.Length));
    }
}
