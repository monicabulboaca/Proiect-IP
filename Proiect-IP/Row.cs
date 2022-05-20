using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IP
{
    public class Row : IEquatable<Row>
    {
        private List<string> _data;

        public Row()
        {
            _data = new List<string>();
        }

        public Row(int numberOfElements)
        {
            _data = new List<string>(numberOfElements + 1);
            for (int i = 0; i < numberOfElements; i++)
            {
                _data.Add("");
            }
        }

        public List<String> Data
        {
            get { return _data; }
            set
            {
                _data.Clear();
                _data = value;
            }
        }

        public bool Equals(Row other)
        {
            if(other.Data.Count != _data.Count)
            {
                return false;
            }

            for (int i = 0; i < _data.Count; i++)
            {
                if(_data.ElementAt(i) != other.Data.ElementAt(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
