﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
            fr.numara = textBox1.Text;
            fr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr1 = new FrmOgretmen();
            fr1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
