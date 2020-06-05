using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using static Cirnix.Global.Component;
using static Cirnix.Global.NativeMethods;

namespace Cirnix.Global
{
    public /*abstract*/ class DraggableLabelForm : MetroForm
    {
        #region [    Title Form Move Event    ]
        private Point FormLocation;
        private bool IsMouseMoveStart = false;
        private POINT LastLocation = new POINT(), CurrentLocation = new POINT();
        protected void Label_Title_MouseDown(object sender, MouseEventArgs e)
        {
            GetCursorPos(out CurrentLocation);
            FormLocation = Location;
            IsMouseMoveStart = true;
        }
        protected void Label_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseMoveStart) return;
            GetCursorPos(out LastLocation);
            FormLocation.X += (LastLocation.X - CurrentLocation.X);
            FormLocation.Y += (LastLocation.Y - CurrentLocation.Y);
            Location = FormLocation;
            CurrentLocation = LastLocation;
        }
        protected void Label_Title_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseMoveStart = false;
        }
        #endregion
    }
}
