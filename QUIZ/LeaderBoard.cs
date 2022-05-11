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
    public partial class LeaderBoard : Form
    {
        struct person
        {
            public string name;
            public int score;
        }
        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            GetTop5Scores();
        }

        private void GetTop5Scores()
        {
            if(!File.Exists("scores.txt"))
            {
                MessageBox.Show("No scores exist please save your score");
                return;
            }
            string[] scores =  System.IO.File.ReadAllLines("scores.txt");
            List<person> people = new List<person>();
            foreach (var item in scores)
            {
                string[] temp = item.Split(',');
                person jeff = new person();
                jeff.name = temp[0];
                jeff.score = int.Parse(temp[1]);
                people.Add(jeff);
            }

            DisplayTop5(MergeSort(people));
        }

        private void DisplayTop5(List<person> people)
        {
            label2.Text = people[0].name; label3.Text = people[0].score.ToString();
            label4.Text = people[1].name; label5.Text = people[1].score.ToString();
            label6.Text = people[2].name; label7.Text = people[2].score.ToString();
            label8.Text = people[3].name; label9.Text = people[3].score.ToString();
            label10.Text = people[4].name; label11.Text = people[4].score.ToString();

        }

        static List<person> MergeLists(List<person> L1, List<person> L2)
        {
            List<person> mergedList = new List<person>();
            int indexLeft = 0, indexRight = 0;
            while (indexLeft < L1.Count || indexRight < L2.Count)
            {
                if (indexLeft < L1.Count && indexRight < L2.Count)
                {
                    if (L1[indexLeft].score > L2[indexRight].score)
                    {
                        mergedList.Add(L1[indexLeft]);
                        indexLeft++;
                    }
                    else
                    {
                        mergedList.Add(L2[indexRight]);
                        indexRight++;
                    }
                }
                else if (indexLeft < L1.Count)
                {
                    mergedList.Add(L1[indexLeft]);
                    indexLeft++;
                }
                else if (indexRight < L2.Count)
                {
                    mergedList.Add(L2[indexRight]);
                    indexRight++;
                }
            }

            return mergedList;
        }

        static List<person> MergeSort(List<person> ListToSort)
        {
            List<person> SortedList = new List<person>();
            List<person> leftList = new List<person>();
            List<person> rightList = new List<person>();

            int half = ListToSort.Count / 2;
            for (int i = 0; i < half; i++)
            {
                leftList.Add(ListToSort[i]);
            }
            for (int i = half; i < ListToSort.Count; i++)
            {
                rightList.Add(ListToSort[i]);
            }

            if (leftList.Count > 1)
                leftList = MergeSort(leftList);
            if (rightList.Count > 1)
                rightList = MergeSort(rightList);

            SortedList = MergeLists(leftList, rightList);
            return SortedList;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main game = new Main();
            this.Hide();
            game.Show();    
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
