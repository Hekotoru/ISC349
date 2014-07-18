using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISC349.PracticaI.Core.Functions
{
    public class DBMSFunctionsHandler : IHandleDBMSFunctions
    {
        public void CreateTable(string tableName, string[] fields)
        {
            if (File.Exists(String.Format("{0}.tbl",tableName)))
            {
                throw new Exception(String.Format("La tabla '{0}' ya existe", tableName));
            }
            using (var writer = new StreamWriter(String.Format("{0}.tbl", tableName)))
            {
                writer.WriteLine(String.Join(",", fields));
            }
        }
        public IList<Object> Select(string fields, string tableName)
        {
            if (!File.Exists(String.Format("{0}.tbl", tableName)))
            {
                throw new Exception(String.Format("La tabla '{0}' no existe", tableName));
            }
            using (var reader = new StreamReader(String.Format("{0}.tbl", tableName)))
            {
                var headers = reader.ReadLine().Split(',');

                while (!reader.EndOfStream)
                {
                    var currentLine = reader.ReadLine();
                    //currentLine[indice_del_field];
                
                }
            }

            throw  new NotImplementedException();
        }
        public void Insert(string tableName, string[] values)
        {
            if (!File.Exists(String.Format("{0}.tbl", tableName)))
            {
                throw new Exception(String.Format("La tabla '{0}' no existe", tableName));
            }
            using (var writer = new StreamWriter(String.Format("{0}.tbl", tableName), true))
            {
                writer.WriteLine(String.Join(",", values));
            }
        }
    }
}
