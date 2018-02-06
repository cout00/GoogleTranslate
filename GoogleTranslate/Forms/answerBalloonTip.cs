﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTranslate.Core.Interfaces;

namespace GoogleTranslate
{
    public partial class answerBalloonTip :Form
    {
        public answerBalloonTip()
        {
            InitializeComponent();
            Visible = false;
        }

        public void ShowPos(int Left, int Right)
        {
            //
        }

        public void ShowResult(string result)
        {
            Notification.Text = result;
            Notification.BalloonTipText = "memem";
            Notification.ShowBalloonTip(1000);
        }
    }
}
