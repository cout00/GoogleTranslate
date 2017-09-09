﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using GoogleTranslate.Core;

[assembly: InternalsVisibleTo("GoogleTranslate.Tests")]

namespace GoogleTranslate
{   
    public partial class answerForm :Form, IShowTypeForm
    {
        internal int DebugLinesCount;
        const int MaxWidth = 200;
        void FormSize(string showText)
        {
            DebugLinesCount = 0;
            label1.Font = new Font(new FontFamily("Arial"), 15);
            var curText = "";
            var curLine = "";           
            for (int i = 0; i < showText.Length;)
            {
                if (showText[i].In(new char[] {',','.','"','!','?'}))
                {                    
                    i++;
                    continue;
                }
                if (TextRenderer.MeasureText(curLine, label1.Font).Width < MaxWidth)
                {
                    curLine += showText[i];
                    curText += showText[i];
                    i++;
                }
                else
                {
                    if (showText[i]!=' ')
                    {
                        curLine += showText[i];
                        curText += showText[i];
                        i++;
                        continue;
                    }
                    DebugLinesCount++;
                    curText += '\n';
                    curLine = "";
                }
            }
            Height = TextRenderer.MeasureText(curText, label1.Font).Height;
            Width = TextRenderer.MeasureText(curText, label1.Font).Width;
            label1.Text = curText;
        }

        public void ShowResult(string result)
        {
            FormSize(result);    
        }

        public answerForm()
        {
            TopMost = true;
            InitializeComponent();
        }
    }
}
