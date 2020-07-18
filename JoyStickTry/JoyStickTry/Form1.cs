using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX.DirectInput;
using System.Runtime.InteropServices;
using WindowsInput.Native;
using WindowsInput;
using System.Threading;

namespace JoyStickTry
{
    public partial class Form1 : Form
    {
        DirectInput input = new DirectInput();
        Joystick stick;
        Joystick[] sticks;
        Keyboard keyboard;

        int sen = 10;
        int x = 0;
        int y = 0;
        int z = 0;
        int i = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void mouse_event(uint flag, uint x2, uint y2, uint btn , uint exInfo);
        private const uint MOUSEEVENT_LEFTDOWN = 0x02;
        private const uint MOUSEEVENT_LEFTUP = 0x04;
        private const uint MOUSEEVENT_LEFTDOWN2 = 0x08;
        private const uint MOUSEEVENT_LEFTUP2 = 0x10;

        public Form1()
        {
            InitializeComponent();
            getSticks();
            sticks = getSticks();
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            menuStrip1.Parent = pictureBox1;
            menuStrip1.BackColor = Color.Transparent;

            pictureBox5.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;

            pictureBox6.Parent = pictureBox1;
            pictureBox6.BackColor = Color.Transparent;

            pictureBox6.Hide();

            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#252525");
            pictureBox2.BackColor = col;
            pictureBox3.BackColor = col;
            pictureBox4.BackColor = col;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < sticks.Length; i++)
            {
                stickHandle(sticks[i], i);
            }
        }

        public Joystick[] getSticks()
        {
            List<Joystick> sticks = new List<Joystick>();
            foreach(DeviceInstance device in input.GetDevices(DeviceClass.GameController,DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new Joystick(input, device.InstanceGuid);
                    stick.Acquire();

                    foreach(DeviceObjectInstance deviceobject in stick.GetObjects())
                    {
                        if((deviceobject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            stick.GetObjectPropertiesById((int)deviceobject.ObjectType).SetRange(-100, 100);
                        }
                    }
                    sticks.Add(stick);
                }
                catch(DirectInputException)
                {

                }
            }
            return sticks.ToArray();
        }

        public void stickHandle(Joystick stick,int id)
        {
            InputSimulator sim = new InputSimulator();

            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            x = state.X;
            y = state.Y;
            z = state.Z;
            MouseMovee(x,y);
            bool[] buttons = state.GetButtons();

            if (buttons[2] == true)
            {
                //Keyboard keyboard2 = new Keyboard();
                //keyboard2.Send(Keyboard.ScanCodeShort.KEY_R);

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)728, (int)806);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);

            }
            else if (buttons[1])
            {
                //Keyboard keyboard2 = new Keyboard();
                //keyboard2.Send(Keyboard.ScanCodeShort.KEY_E);

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)675, (int)795);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
            }
            else if (buttons[3])
            {
                //Keyboard keyboard2 = new Keyboard();
                //keyboard2.Send(Keyboard.ScanCodeShort.F4);

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)780, (int)792);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
            }
            else if (buttons[0])
            {
                //Keyboard keyboard2 = new Keyboard();
                //keyboard2.Send(Keyboard.ScanCodeShort.KEY_W);

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)614, (int)795);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
            }
            else if (buttons[4])
            {
                mouse_event(MOUSEEVENT_LEFTDOWN , 0, 0, 0, 0);
                Thread.Sleep(200);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
            }
            else if (buttons[5])
            {
                mouse_event(MOUSEEVENT_LEFTDOWN2, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP2, 0, 0, 0, 0);
                
            }
            else if (buttons[6])
            {
                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)850, (int)800);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
            }
            else if (buttons[7])
            {
                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)900, (int)800);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
            }
            else if (buttons[8])
            {
                //Keyboard keyboard2 = new Keyboard();
                //keyboard2.Send(Keyboard.ScanCodeShort.F4);

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)950, (int)800);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(150);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
            }
            else if (buttons[9])
            {
                SendKeys.Send("/all GLHF");
                Thread.Sleep(180);
            }
            else if (buttons[10])
            {
                //sim.Mouse.RightButtonDown();

                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)850, (int)800);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
            }
            else if (buttons[11])
            {
                int xx = Cursor.Position.X;
                int yy = Cursor.Position.Y;
                Cursor.Position = new Point((int)900, (int)800);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                Cursor.Position = new Point((int)xx, (int)yy);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(30);
                mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);

                //SendKeys.Send("{Enter}");
                //Thread.Sleep(180);
            }
            else if (buttons[12])
            {
                Thread.Sleep(200);
                if (sen == 16)
                {
                    sen = 6;
                }
                else
                {
                    sen = sen + 2;
                }
                label5.Text = sen.ToString() + "          ";
            }
            else if (buttons[13] == true)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                sim.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            }
            else if (buttons[14] == true)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.VK_4);
                sim.Keyboard.KeyUp(VirtualKeyCode.VK_4);
            }
            else if (buttons[15] == true)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                sim.Keyboard.KeyUp(VirtualKeyCode.VK_5);
            }
            else if (buttons[16] == true)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                sim.Keyboard.KeyUp(VirtualKeyCode.VK_3);
            }
            else if (buttons[17] == true)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                sim.Keyboard.KeyUp(VirtualKeyCode.VK_3);
            }
        }

        public void MouseMovee(int posx,int posy)
        {
            Cursor.Position = new Point(Cursor.Position.X + posx/sen, Cursor.Position.Y + posy/sen);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = getSticks();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                MessageBox.Show(Cursor.Position.ToString(), "Cursor Position");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please email chuanyou1997@gmail.com for technical support.", "LOL Joystick App Beta - Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Hide();
            pictureBox5.Show();

            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox6.Show();
            pictureBox5.Hide();

            timer1.Stop();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}
