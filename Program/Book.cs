namespace Program;

public class Book
{
    public string title {get;set;}
    public int publication_year {get;set;}
    public string author {get;set;}
    public string isbn {get;set;}
}

public class Author
{
    public Author(string author, string bookName)
    {
        if(author.Contains('('))
        {
            author = author.Substring(0,author.IndexOf('('));
        }
        string[] fullName = author.Split(' ');
        FirstName = fullName[0];
        LastName = fullName[fullName.Length-1];
        Name = author;
        Bibliography.Add(bookName);
    }
    public string Name {get; set;}
    public string LastName {get; set;}
    public string FirstName {get; set;}
    public List<string> Bibliography = new List<string>();
}