using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bingo
{
    public class PlayItem : Label
    {
        bool selected = false;
        int nbr = 0;
        Image image;
        
        public int Value
        {
            get { return nbr; } 
            set { nbr = value; }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                selectionColor();
            }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public PlayItem()
        {

        }

        public PlayItem(PlayItemInfo playItemInfo) : this()
        {
            this.Value = playItemInfo.Value;
            this.Text = playItemInfo.Value.ToString();
            this.Selected = playItemInfo.Selected;
            this.BackColor = playItemInfo.BackColor;
        }

        public void selectionColor()
        {
            if (Selected)
                this.BackColor = Color.Red;
            else
                this.BackColor = SystemColors.Control;
        }


    }
}
