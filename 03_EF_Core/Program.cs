// See https://aka.ms/new-console-template for more information

using var ctx = new MyDbContext();
// await initT_Books(ctx);

var guid = Guid.NewGuid();
System.Console.WriteLine($"guid:{guid}");

await TestQuery(ctx);

// await TestUpdateAndDelete(ctx);

static async Task TestUpdateAndDelete(MyDbContext ctx)
{
    var book = ctx.Books.Single(b=>b.Id == 1);
    book.AuthorName = "Jyun";

    var person = ctx.Persons.Single(b=>b.Id == 4);
    ctx.Persons.Remove(person);

    await ctx.SaveChangesAsync();
}

static async Task TestQuery(MyDbContext ctx)
{
    var items = ctx.Books.GroupBy(b => b.AuthorName)
    .Select(g => new { Name = g.Key, BookCount = g.Count(), MaxPrice = g.Max(b => b.Price) });
    foreach (var item in items)
    {
        System.Console.WriteLine($"Name:{item.Name},BookCount:{item.BookCount},MaxPrice:{item.MaxPrice},");
    }


    var find = ctx.Books.SingleOrDefault(b => b.Id == 1);
    System.Console.WriteLine(find?.Title);

    var books = ctx.Books.Where(b => b.Price > 80).OrderByDescending(b => b.Price);
    foreach (var book in books)
    {
        System.Console.WriteLine($"title:{book.Title}, price:{book.Price}");
    }
}


static async Task TestAddBook(MyDbContext ctx)
{
    var book = new Book();
    book.Title = "Title";
    book.Id = 1;
    book.PubTime = DateTime.Now.ToUniversalTime();
    book.Price = 12.4d;

    System.Console.WriteLine(DateTime.Now.ToUniversalTime());

    ctx.Books.Add(book);

    await ctx.SaveChangesAsync();
}


static async Task initT_Books(MyDbContext ctx)
{
    var b1 = new Book
    {
        AuthorName = "杨中科",
        Title = "零基础趣学C语言",
        Price = 59.8,
        PubTime = new DateTime(2019, 3, 1)
    };
    var b2 = new Book
    {
        AuthorName = "Robert Sedgewick",
        Title = "算法(第4版)",
        Price = 99,
        PubTime = new DateTime(2012, 10, 1)
    };
    var b3 = new Book
    {
        AuthorName = "吴军",
        Title = "数学之美",
        Price = 69,
        PubTime = new DateTime(2020, 5, 1)
    };
    var b4 = new Book
    {
        AuthorName = "杨中科",
        Title = "程序员的SQL金典",
        Price = 52,
        PubTime = new DateTime(2008, 9, 1)
    };
    var b5 = new Book
    {
        AuthorName = "吴军",
        Title = "文明之光",
        Price = 246,
        PubTime = new DateTime(2017, 3, 1)
    };
    var books = new Book[] { b1, b2, b3, b4, b5 };

    foreach (var book in books)
    {
        book.PubTime = book.PubTime.ToUniversalTime();
        System.Console.WriteLine(book.PubTime);
        ctx.Add(book);
    }
    await ctx.SaveChangesAsync();

}