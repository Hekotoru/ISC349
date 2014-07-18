using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISC349.PracticaI.Core.Functions
{
    public interface IHandleDBMSFunctions 
    {
        void CreateTable(string tableName, string[] fields);
        IList<Object> Select(string fields, string table);
        void Insert(string tableName, string[] values);
    }
}
