using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    [Serializable]
    public class Text
    {
        public Text()
        {

        }
        public String SavedText { get; set; }
        public int zOrder { get; set; }
        public Color Color { get; set; }
        public Color BackColor { get; set; }
        public Point Location { get; set; } = new Point(0, 0);
        public Font Font { get; set; }

        public static implicit operator string(Text v)
        {
            throw new NotImplementedException();
        }

        //public Rotation ?         Not sure what data type rotation will be. Add when available
    }
}
