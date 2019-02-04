using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNineProject.Models
{
    public interface IRepository
    {
        DocViewModel FindDoc(int Id);

        void AddDoc(DocViewModel NewDoc);

        void DeleteDoc(int Id);

        void UpdateDoc(DocViewModel updDoc);

        List<DocViewModel> DocsToList();

        void Save();
    }
}
