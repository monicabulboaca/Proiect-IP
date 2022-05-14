using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP.interfaces
{
    interface IDatabaseModeler
    {
        void AddData(in List<string> data);
        void DeleteData(in List<string> data);
        void ReadData(in string filePath); 
        void UpdateData(in List<string> oldData, in List<string> newData);
    }
}
