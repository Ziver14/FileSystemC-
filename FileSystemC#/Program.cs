using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;

namespace FileSystemC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();

            //XmlElement root = xmlDocument.CreateElement("Bookstore");
            //xmlDocument.AppendChild(root);

            //XmlElement book = xmlDocument.CreateElement("book");
            //book.SetAttribute("ISBN", "123456");
            //root.AppendChild(book);

            //XmlElement title = xmlDocument.CreateElement("title");
            //title.InnerText = "C# Progoraming";
            //book.AppendChild(title);

            //xmlDocument.Save("book.xml");

            //xmlDocument.Load("book.xml");
            //XmlNode root = xmlDocument.DocumentElement;
            //foreach (XmlNode bookNode in root.ChildNodes)
            //{
            //    Console.WriteLine($"Book ISBM{bookNode.Attributes["ISBN"].Value}");
            //    Console.WriteLine($"Title: {bookNode["title"].InnerText} ");
            //}

            //XmlNode bookNode = xmlDocument.SelectSingleNode("/Bookstore/book[@ISBN ='123456']/title");
            //if (bookNode != null ) 
            //{
            //    bookNode.InnerText = "Update";
            //}
            //xmlDocument.Save("book.xml");

            string filePath = "output.txt";

            //Создание и чтение файла
            //using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            //{
            //    string text = "Hello";
            //    byte[] buffer = System.Text.Encoding.ASCII.GetBytes(text);

            //    fileStream.Write(buffer, 0, buffer.Length);
            //}

            //using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //{
                
            //    byte[] buffer = new byte[1024];
            //    int byteRead;

            //    while((byteRead = fileStream.Read(buffer, 0, buffer.Length)) > 0) 
            //    {
            //        string text = System.Text.Encoding.ASCII.GetString(buffer,0,byteRead);
            //        Console.WriteLine(text);
            //    }

              
            //}

            //using (StreamWriter writer = new StreamWriter(filePath, true)) 
            //{
            //    writer.WriteLine("\nHAHAHAHA");
            //}

            //using(StreamReader reader = new StreamReader(filePath))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            //Console.WriteLine(File.ReadAllText(filePath));

            //var person = new {Name = "Alice", Age=30, IsMaried=false};

            //string json = JsonConvert.SerializeObject(person);

            //Console.WriteLine(json);

            //var deserialized = JsonConvert.DeserializeObject<Person>(json);
            //Console.WriteLine($"Name:{deserialized.Name},Age: {deserialized.Age},IsMaried {deserialized.IsMaried}");
            

            List<Book> books = new List<Book>();

            XDocument xmlDoc = XDocument.Load("books.xml");
            foreach(var element in xmlDoc.Element("books").Elements("book")) 
            {
                Book book = new Book
                {
                    Title = element.Element("title").Value,
                    Author = element.Element("author").Value,
                    Year = int.Parse(element.Element("year").Value)

                };
                books.Add(book);
            }

            using (StreamReader r = new StreamReader("books.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach(var item in array.books)
                {
                    Book book = new Book
                    {
                        Title = item.title,
                        Author = item.author,
                        Year = item.year

                    };
                    books.Add(book);
                }
            }
            
            using (StreamReader r = new StreamReader("books.txt")) 
            {
                string line;
                while((line = r.ReadLine()) != null)
                {
                    string[]parts = line.Split(',');
                    if (parts.Length == 3)
                    {

                        Book book = new Book
                        {
                            Title = parts[0].Trim(),
                            Author = parts[1].Trim(),
                            Year = int.Parse((parts[2]).Trim())

                        };
                        books.Add(book);

                    }
                }
            }

                foreach (var book in books) 
            {
                Console.WriteLine($"{book.Title} , {book.Author} , {book.Year}");
            }


        }
    }
}
 public class Person
{
    public string Name { get; set; }
    public string Age { get; set; }
    public string IsMaried { get; set;}
}
