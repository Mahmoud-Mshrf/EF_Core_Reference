namespace Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BookWithAuthour();
            //AuthorWithNationality();
            //JoinMethod();
            //JoinMethod2();
            //Join2x1MethodExamble();
            //GroupJoinMethod();
            //GroupJoinQuery();
            GroupJoinMethodExampleComplicated();

        }

        private static void GroupJoinMethodExampleComplicated()
        {
            var context = new AppDbContext();
            var books = context.Books
            .Join(context.Authors, book => book.AuthorId, author => author.Id,
            (book, author) => new
            {
                Bookld = book.Id,
                BookName = book.Name,
                AuthorName = author.Name,
                AuthorNationalityld = author.NationalityId
            })
            .GroupJoin(context.Nationalities,
            book => book.AuthorNationalityld,
            nationality => nationality.Id,
            (book, nationality) => new
            {
                Book = book,
                Nationality = nationality
            })
            .SelectMany(
            b => b.Nationality.DefaultIfEmpty(),
            (b, n) => new { b.Book, Nationality = n });

            foreach (var book in books)
                System.Console.WriteLine($" {book.Book.Bookld} {book.Book.BookName} {book.Book.AuthorName}{book.Nationality.Name}");

        }

        private static void GroupJoinQuery()
        {
            using var context = new AppDbContext();
            var Authors = context.Authors;
            var Books = context.Books;
            var BooksAuthors = from author in Authors
                               join book in Books on author.Id equals book.AuthorId
                               into bookAuthors
                               select new
                               {
                                   AuthorName = author.Name,
                                   books = bookAuthors.Select(b => b.Name).ToList()
                               };
            foreach (var item in BooksAuthors)
            {
                Console.WriteLine(item.AuthorName+" Books :");
                foreach (var book in item.books)
                {
                    Console.WriteLine("   "+book);
                }
            }
        }

        private static void GroupJoinMethod()
        {
            using var context = new AppDbContext();
            var Books = context.Books;
            var Authors = context.Authors;
            var BooksAuthors = Authors.GroupJoin(Books, author => author.Id, books => books.AuthorId, (author,books) =>
                               new
                               {
                                   AuthorName = author.Name,
                                   AuthorBooks= books.Select(b=>b.Name).ToList()
                                   
                               });
            foreach (var item in BooksAuthors)
            {
                Console.WriteLine($"{item.AuthorName} Books :");
                foreach (var book in item.AuthorBooks) 
                {
                    Console.WriteLine("   "+book);
                }
            }
        }
        

        private static void Join2x1MethodExamble()
        {
            using var context = new AppDbContext();
            var Books = context.Books;
            var Authors = context.Authors;
            var BookWithAuthorsWithNationality = Books.Join(Authors, book => book.AuthorId, author => author.Id, (book, author) => new
            {
                BookName = book.Name,
                AuthorName = author.Name,
                AuthorNationalityId = author.NationalityId
            })
                .Join(context.Nationalities, BookWithAuthor => BookWithAuthor.AuthorNationalityId, nationality => nationality.Id, (bookWithAuthor, nationality) => new
                {
                    NationalityName = nationality.Name,
                    bookWithAuthor.BookName,
                    bookWithAuthor.AuthorName,
                });
            foreach (var item in BookWithAuthorsWithNationality)
            {
                Console.WriteLine($"{item.BookName} Was Written By {item.AuthorName} His Nationality Is {item.NationalityName}");
            }
        }
        private static void Join2x1QueryExamble()
        {
            // هو انا مش عارف اذا كانت الكويري بتسمح باكتر من جوين سوا ولا لا بس لسه هنشوف ف هنا الكود القديم لحد ما الاقيها ان شاء الله 
            using var context = new AppDbContext();
            var Books = context.Books;
            var Authors = context.Authors;
            var BookWithAuthorsWithNationality = Books.Join(Authors, book => book.AuthorId, author => author.Id, (book, author) => new
            {
                BookName = book.Name,
                AuthorName = author.Name,
                AuthorNationalityId = author.NationalityId
            })
                .Join(context.Nationalities, BookWithAuthor => BookWithAuthor.AuthorNationalityId, nationality => nationality.Id, (bookWithAuthor, nationality) => new
                {
                    NationalityName = nationality.Name,
                    bookWithAuthor.BookName,
                    bookWithAuthor.AuthorName,
                });
            foreach (var item in BookWithAuthorsWithNationality)
            {
                Console.WriteLine($"{item.BookName} Was Written By {item.AuthorName} His Nationality Is {item.NationalityName}");
            }
        }
        private static void JoinMethod2()
        {
            using var context = new AppDbContext();
            var Books = context.Books;
            var Authors = context.Authors;
            var BooksAuthors = Books.Join(Authors,book=>book.AuthorId,author=>author.Id , (book,author) =>
                               new BookAuthor
                               {
                                   BookName = book.Name,
                                   AuthorName = author.Name,
                               });
            foreach (var item in BooksAuthors)
            {
                Console.WriteLine(item);
            }
        }

        private static void JoinMethod()
        {
            using var context = new AppDbContext();
            var Authors = context.Authors;
            var Nationalities = context.Nationalities;
            var AuthorsNationality = Authors.Join(Nationalities, author => author.NationalityId, nationality => nationality.Id, (author, nationality) =>
            new AuthorNationality
            {
                AuthorName = author.Name,
                NationalityName = nationality.Name,
            });

            foreach (var item in AuthorsNationality)
            {
                Console.WriteLine(item);
            }
        }

        private static void AuthorWithNationality()
        {
            using var context = new AppDbContext();
            var Authors = context.Authors;
            var Nationalities = context.Nationalities;
            var AuthorsNationality = from author in Authors
                                     join nationality in Nationalities on author.NationalityId equals nationality.Id
                                     select new AuthorNationality
                                     {
                                         AuthorName= author.Name,
                                         NationalityName= nationality.Name,
                                     };
            foreach (var item in AuthorsNationality)
            {
                Console.WriteLine(item);
            }
        }

        private static void BookWithAuthour()
        {
            using var context = new AppDbContext();
            var Books = context.Books;
            var Authors = context.Authors;
            var BooksAuthors = from book in Books
                               join author in Authors on book.AuthorId equals author.Id
                               select new BookAuthor
                               {
                                   BookName = book.Name,
                                   AuthorName = author.Name,
                               };
            foreach (var item in BooksAuthors)
            {
                Console.WriteLine(item);
            }
        }
    }


    public class BookAuthor
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public override string ToString()
        {
            return $"{BookName} Was Written By {AuthorName}";
        }
    }
    public class AuthorNationality
    {
        public string AuthorName { get; set; }
        public string NationalityName { get; set; }

        public override string ToString()
        {
            return $"{AuthorName} From {NationalityName}";
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalityId { get; set; }
    }
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}