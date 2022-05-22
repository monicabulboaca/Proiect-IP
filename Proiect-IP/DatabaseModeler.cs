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
        private List<Row> _records; 

        public DatabaseModeler(List<string> fields, List<Row> data)
        {
            this._fields = fields;
            this._records = data;
        }

        public int NumberOfRows { get { return _records.Count; } }

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

        public void UpdateData(int row, int column, string newData)
        {
            if(row > _records.Count-1)
            {
                _records.Add(new Row(_fields.Count));
            }
            _records[row].Data[column] = newData;
        }

        public List<string> GetFields()
        {
            return _fields;
        }

        public List<Row> GetRecords()
        {
            return _records;
        }
    }
}
