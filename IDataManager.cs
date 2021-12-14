using System.Collections.Generic;

namespace Library
{
    interface IDataManager
    {
        bool Save(List<Book> library, string filePath);

        List<Book> Load(string filePath);
    }
}