using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    [Serializable]
    internal class Document
    {
        public List<Text> TextList { get; set; } = new List<Text>();
    }
}
