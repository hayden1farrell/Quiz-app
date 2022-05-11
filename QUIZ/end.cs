using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZ
{
    public partial class end : Form
    {
        private int _score = 0;
        public end(int score)
        {
            _score = score;
            InitializeComponent();
            label3.Text = score.ToString();
        }

        private void SaveScore()
        {
            if (!File.Exists("scores.txt"))
            {
                using (StreamWriter writer = File.AppendText("scores.txt"))
                {
                    writer.WriteLine($"---,-1");
                    writer.WriteLine($"---,-1");
                    writer.WriteLine($"---,-1");
                    writer.WriteLine($"---,-1");
                    writer.WriteLine($"{textBox1.Text},{_score}");
                }
            }
            else
            {
                using (StreamWriter appender = File.AppendText("scores.txt"))
                    appender.WriteLine($"{textBox1.Text},{_score}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main game = new Main();
            this.Hide();
            game.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = textBox1.Text.Length > 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button3 .Enabled = false;
            SaveScore();
        }

        private void end_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LeaderBoard board = new LeaderBoard();
            this.Hide();
            board.Show();
        }
    }
}
