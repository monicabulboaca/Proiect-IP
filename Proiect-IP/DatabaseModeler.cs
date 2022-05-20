using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP
{
    public class DatabaseModeler : IDatabaseModeler
    {
        private List<string> _fields;
        private List<Row> _records; // ?? list<list<string>> ??, da chiar asa

        public DatabaseModeler(List<string> fields, List<Row> data)
        {
            this._fields = fields;
            this._records = data;
        }

        public void AddData(Row data)
        {
            _records.Add(data);
        }

        public void DeleteData(Row data)
        {
            foreach (var row in _records)
            {
                if (data == row)
                {
                    _records.Remove(row);
                    break;
                }
            }
        }

        public void ReadData(string filePath)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Row oldData, Row newData)
        {
            foreach (var row in _records)
            {
                if(row.Equals(oldData))
                {
                    row.Data = oldData.Data;
                }
            }
        }
    }
}
