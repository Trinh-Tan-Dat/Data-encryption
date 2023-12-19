using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Bai1 : Form
    {
        private char[,] keyMatrix;

        public Bai1()
        {
            InitializeComponent();
            initDataGridView();
        }
        private void initDataGridView()
        {
            guna2DataGridView1.ColumnCount = 5;
            guna2DataGridView1.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                guna2DataGridView1.Columns[i].Width = 20;
                guna2DataGridView1.Rows[i].Height = 20;
            }
        }
        private String splitText(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                result.Append(input[i]);

                if (i % 2 != 0 && i < input.Length - 1)
                {
                    result.Append(" ");
                }
            }
            return result.ToString();
        }
        private char[,] GenerateKeyMatrix(string key)
        {
            List<char> uniqueChars = key.Distinct().ToList();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c != 'J' && !uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
            }
            char[,] matrix = new char[5, 5];
            int index = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = uniqueChars[index];
                    index++;
                }
            }
            return matrix;
        }

        private void DisplayKeyMatrix()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    guna2DataGridView1.Rows[i].Cells[j].Value = keyMatrix[i, j];
                }
            }
        }
        private string appendSpace(string input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                result.Append(input[i]);

                if (i > 0 && i % 2 != 0)
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }
        private void encrypt(string split)
        {
            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < split.Length; i += 2)
            {
                char char1 = split[i];
                char char2 = split[i + 1];

                int[] pos1 = GetPosition(char1);
                int[] pos2 = GetPosition(char2);

                if (pos1[0] == pos2[0])
                {
                    encryptedText.Append(keyMatrix[pos1[0], (pos1[1] + 1) % 5]);
                    encryptedText.Append(keyMatrix[pos2[0], (pos2[1] + 1) % 5]);
                }
                else if (pos1[1] == pos2[1])
                {
                    encryptedText.Append(keyMatrix[(pos1[0] + 1) % 5, pos1[1]]);
                    encryptedText.Append(keyMatrix[(pos2[0] + 1) % 5, pos2[1]]);
                }
                else
                {
                    encryptedText.Append(keyMatrix[pos1[0], pos2[1]]);
                    encryptedText.Append(keyMatrix[pos2[0], pos1[1]]);
                }
            }

            String temp = encryptedText.ToString();
            temp = appendSpace(temp);
            guna2TextBox3.Text = temp;
        }

        private int[] GetPosition(char c)
        {
            int[] position = new int[2];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (keyMatrix[i, j] == c)
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }

            return position;
        }
        private void Bai1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            textBox1.SelectionStart = textBox1.Text.Length;
            String input = textBox1.Text.ToUpper();
            input = input.Replace(" ", "");
            if (input.Length % 2 != 0)
            {
                input = string.Concat(input, "X");
            }
            keyMatrix = GenerateKeyMatrix(input);
            DisplayKeyMatrix();
        }

        private void Bai1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.Text = guna2TextBox1.Text.ToUpper();
            guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
            String encryptText = guna2TextBox1.Text.ToUpper();
            encryptText = encryptText.Replace(" ", "");
            if (encryptText.Length % 2 != 0)
            {
                encryptText = string.Concat(encryptText, "X");
            }
            String split = splitText(encryptText);
            guna2TextBox2.Text = split;
            encrypt(encryptText);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
