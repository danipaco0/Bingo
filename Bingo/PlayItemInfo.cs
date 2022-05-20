using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bingo
{
    [Serializable]
    public class PlayItemInfo
    {
        public int Value { get; set; }
        public bool Selected { get; set; }
        public Color BackColor { get; set; }

        public Image Image { get; set; }

        public PlayItemInfo()
        {

        }

        public PlayItemInfo(PlayItem p)
        {
            this.Value = p.Value;
            this.Selected = p.Selected;
            this.BackColor = p.BackColor;
            this.Image = p.Image;
        }

        
    }
}
