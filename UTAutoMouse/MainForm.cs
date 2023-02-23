using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace UTAutoMouse
{
    /// <summary>
    /// [REF]
    /// 1. Auto Click : https://diy-dev-design.tistory.com/13
    /// 2. Cross thread exception : https://manniz.tistory.com/entry/CC-Sharp-%ED%81%AC%EB%A1%9C%EC%8A%A4-%EC%8A%A4%EB%A0%88%EB%93%9C-%EC%9E%91%EC%97%85%EC%9D%B4-%EC%9E%98%EB%AA%BB%EB%90%98%EC%97%88%EC%8A%B5%EB%8B%88%EB%8B%A4-%EB%B0%94%EB%A1%9C-%ED%95%B4%EA%B2%B0%ED%95%98%EA%B8%B0
    /// 3. Get Mouse Position : https://sosal.kr/793
    /// 4. Systime Mouse Hook : https://nowonbun.tistory.com/122
    ///                         https://kjun.kr/1039
    /// </summary>
    public partial class MainForm : Form
    {


        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        #region [Mouse Position]
        private const int MouseEV_Move = 0x0001;        /* mouse move 			*/
        private const int MouseEV_LeftDown = 0x0002;    /* left button down 	*/
        private const int MouseEV_LeftUp = 0x0004;  /* left button up 		*/
        private const int MouseEV_RightDown = 0x0008; 	/* right button down 	*/

        private int MouseSetPosX = 0;
        private int MouseSetPosY = 0;

        private int interval_;
        private readonly ManualResetEvent stoppeing_event_ = new ManualResetEvent(false); //System.Threading;
        #endregion

        private static System.Timers.Timer aTimer;
        private bool isRunningTracking = false;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hook.GlobalEvents().MouseClick += GlobalHook_MouseClick;

            lstPositionList.View = View.Details;
            lstPositionList.GridLines = true;
            lstPositionList.FullRowSelect = true;
            lstPositionList.CheckBoxes = true;

            lstPositionList.Columns.Clear();
            lstPositionList.Columns.Add("Title", 150, HorizontalAlignment.Center);
            lstPositionList.Columns.Add("X Pos", 50, HorizontalAlignment.Center);
            lstPositionList.Columns.Add("Y Pos", 50, HorizontalAlignment.Center);
        }

        private void GlobalHook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                btnTrackingPos_Click(null, null);
            }
        }

        public void MouseSetPosNclick(int x, int y)
        {
            try
            {
                SetCursorPos(x, y);
                stoppeing_event_.WaitOne(interval_);
                MouseClick_now();
            }
            catch (Exception e)
            {
                MessageBox.Show("MouseSetPosNclick\r\n" + e.Message);
            }
        }

        public void MouseClick_now()
        {
            try
            {
                mouse_event(MouseEV_LeftDown, 0, 0, 0, 0);
                mouse_event(MouseEV_LeftUp, 0, 0, 0, 0);
                stoppeing_event_.WaitOne(100);
            }
            catch (Exception e)
            {
                MessageBox.Show("MouseClick_now\r\n" + e.Message);
            }
        }

        private void btnTrackingPos_Click(object sender, EventArgs e)
        {
            if (!isRunningTracking)
            {
                isRunningTracking = true;
                aTimer = new System.Timers.Timer(100);
                aTimer.Elapsed += ATimer_Elapsed;
                aTimer.Enabled = true;
            }
            else
            {
                MouseSetPosX = Convert.ToInt32(txtCursorPosX.Text);
                MouseSetPosY = Convert.ToInt32(txtCursorPosY.Text);

                isRunningTracking = false;
                aTimer.Enabled = false;
            }
        }

        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            txtCursorPosX.Text = Cursor.Position.X.ToString(); 
            txtCursorPosY.Text = Cursor.Position.Y.ToString();


        }

        private void btnAutoClick_Click(object sender, EventArgs e)
        {
            MouseSetPosNclick(MouseSetPosX, MouseSetPosY);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            ListViewItem lv = new ListViewItem(txtTitle.Text);
            lv.SubItems.Add(MouseSetPosX.ToString());
            lv.SubItems.Add(MouseSetPosY.ToString());
            lstPositionList.Items.Add(lv);

            txtTitle.Text = String.Empty;

        }

        public class CPosition
        {
            public string title { get; set; }
            public int posX { get; set; }
            public int posY { get; set; }
        }

    }
}
