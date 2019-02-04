using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNineProject.Models
{
    public interface IRepository
    {
        void Add(Doc doc);

        void Add(Person person);

        void Add(Executor executor);

        List<Doc> DocsToList();

        List<Person> PersonsToList();

        List<Executor> ExecutorsToList();

        Doc FindFullDoc(int? id);

        Person FindPerson(int id);

        Executor FindExecutor(int id);

        void Save();
    }
}
