using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class TextInputEventArgs : EventArgs
    {
        public Text TextInput { get; private set; }

        public TextInputEventArgs(Text TextInput)
        {
            this.TextInput = TextInput;
        }
    }
}
