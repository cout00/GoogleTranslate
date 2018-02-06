using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using FTranslate.Core;
using FTranslate.Core.Interfaces;
using FTranslate.Core.Yandex;

namespace GoogleTranslate
{
    public partial class emptyForm :Form
    {        
        //IShowTypeForm curForm;

        public emptyForm()
        {
            InitializeComponent();
            
            //curForm = new answerForm();
            WindowsApiHelper.OnKeyPush += Kh_OnKeyPush;
            WindowsApiHelper.SetKeyBoardHook();
        }
        
        
        private void Kh_OnKeyPush(object sender, WindowsApiHelper.KeyPressedArgs e)
        {
            InputSimulator isim = new InputSimulator();
            isim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_C);
            
            var t = Clipboard.GetText();
            //YandexParser parser = new YandexParser(new YandexHttpRequest(),t);
            //var tr= parser.GetTranslate();
            //if (tr.Item1 == null)
            //{
            //    curForm.ShowPos(lpPoint.X, lpPoint.Y);
            //    curForm.ShowResult(tr.Item2);                               
            //}
            //else
            //    throw tr.Item1;
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
