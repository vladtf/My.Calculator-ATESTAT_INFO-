﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace My.Calculator
{
    public partial class Calculator : UserControl
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Calculator()
        {
            InitializeComponent();
            CreateButton();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SendToBack();
        }

        private void button_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string str = textBox_Result.Text;
            Expression f = new Expression(str);
            textBox_Result.Text = f.calculate().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "";
        }

        private void textBox_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button15.PerformClick();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string str = textBox_Result.Text;
            str = "sqrt(" + str + ")";
            textBox_Result.Text = str;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string str = textBox_Result.Text;
            str = "(" + str + ")^2";
            textBox_Result.Text = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = textBox_Result.Text;
            str = str.Substring(0, str.Length - 1);
            textBox_Result.Text = str;
        }

        
        private void CreateButton()
        {
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonBack.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.ForeColor = BackColor;
            buttonBack.UseVisualStyleBackColor = true;


        }

        private void buttonBack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                    textBox_Result.Text = textBox_Result.Text.Substring(0, textBox_Result.Text.Length - 1);
                else
                     textBox_Result.Text = textBox_Result.Text + e.KeyCode.ToString().ToLower();
            }
            catch { }
        }
    }
}
