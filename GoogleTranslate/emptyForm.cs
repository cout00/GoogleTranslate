using GoogleTranslate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
//using DBWorkStation;

namespace GoogleTranslate
{
    public partial class emptyForm :Form
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        IShowTypeForm curForm;



        public emptyForm()
        {
            InitializeComponent();
            KeyHook kh = new KeyHook();
            kh.ShiftAndControlHook();
            KeyHook.OnKeyPush += Kh_OnKeyPush;
            curForm = new answerForm();
            
        }

        private void Kh_OnKeyPush(object sender, KeyHook.KeyPressedArgs e)
        {
            InputSimulator isim = new InputSimulator();
            isim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_C);
            Point lpPoint;
            GetCursorPos(out lpPoint);
            var t = Clipboard.GetText();
            YandexParser parser = new YandexParser(new YandexHttpRequest(),t);
            var tr= parser.GetTranslate();
            if (tr.Item1 == null)
            {
                curForm.ShowPos(lpPoint.X, lpPoint.Y);
                curForm.ShowResult(tr.Item2);                               
            }
            else
                throw tr.Item1;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Clipboard.GetText();
        }
    }
}
