using Bibliotekarz.Data.Model;

namespace Bibliotekarz.Web.Models
{
    public class IndexViewModel
    {
        public ICollection<Book> BookList { get; set; }

        public IndexViewModel()
        {
            //List<Book> lista = new List<Book>();
            //lista.Add(new Book());
            //lista.Remove(lista[0]);

            //Dictionary<int, Book> dic = new Dictionary<int, Book>();
            //dic.Add(11, new Book());
            //dic.Add(22, new Book());
            //Book bookFromDic = dic[22];
            //dic.Remove(22);

            //Queue<Book> queue = new Queue<Book>();
            //queue.Enqueue(new Book());
            //queue.Enqueue(new Book());
            //var bookFromQueue = queue.Dequeue();

            //Stack<Book> stack = new Stack<Book>();
            //stack.Push(new Book());
            //stack.Push(new Book());

            //var bookFromStack = stack.Pop();
        }
    }
}
