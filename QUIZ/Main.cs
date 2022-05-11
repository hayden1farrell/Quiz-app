using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZ
{
    public partial class Main : Form
    {
        private Quiz game = new Quiz();
        bool excuting = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetAnswers();
        }

        private void SetAnswers()
        {
            if (game.QuestionsLeft < 0) GameOver();
            else
            {
                Question quest = game.GetNextQuestion();
                label2.Text = quest.QuestionText;
                button1.Text = quest.Answer1;
                button2.Text = quest.Answer2;
                button3.Text = quest.Answer3;
                button4.Text = quest.Answer4;
                label8.Text = (game.QuestionsLeft + 1).ToString();
                label10.Text = game.Score.ToString();
            }
        }

        private void GameOver()
        {
            int score = game.Score;
            end endscreen = new end(score);
            this.Hide();
            endscreen.Show();
        }

        private async Task SelectAnswerAsync(int v, Button btn)
        {
            if (excuting) return;
            excuting = true;
            bool correct = game.CheckAnswer(v);
            if (correct) btn.BackColor = Color.LightGreen;
            else btn.BackColor = Color.Tomato;

            await Task.Delay(100);
            btn.BackColor = Color.White;

            SetAnswers();
            excuting = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            _ = SelectAnswerAsync(0, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = SelectAnswerAsync(1, button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _ = SelectAnswerAsync(2, button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ = SelectAnswerAsync(3, button4);
        }
    }
}
