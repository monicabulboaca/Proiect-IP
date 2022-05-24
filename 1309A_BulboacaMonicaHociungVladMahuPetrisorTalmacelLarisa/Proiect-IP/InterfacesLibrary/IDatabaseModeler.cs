using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Interfaces
{
    public interface IDatabaseModeler
    {
        void AddData(Row data);
        void DeleteData(Row data);
        void ReadData(string filePath); 
        void UpdateData(int row, int column, string newData);
        int NumberOfRows { get; }
        List<string> GetFields();
        List<Row> GetRecords();
    }
}
