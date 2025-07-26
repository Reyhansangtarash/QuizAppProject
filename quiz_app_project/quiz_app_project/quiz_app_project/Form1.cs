using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace quiz_app_project
{
    public partial class Form1 : Form
    {
        private List<Question> questions = new List<Question>();
        private List<Button> optionButtons = new List<Button>();
        private int currentIndex = 0;
        private int score = 0;
        private Users currentUser;

        public Form1()
        {
            InitializeComponent();

            // Load quiz questions
            questions.AddRange(new List<Question>
        {
            new Question("2 + 2 =", new[] { "3", "4", "5", "6" }, 1),
            new Question("12 / 3 =", new[] { "2", "3", "4", "5" }, 2),
            new Question("5 * 2 =", new[] { "10", "12", "8", "5" }, 0),
            new Question("6 - 1 =", new[] { "5", "6", "7", "4" }, 0),
            new Question("3 + 6 =", new[] { "8", "9", "10", "7" }, 1),
        });
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string name = txt_UserName.Text.Trim();
            if (string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(txt_Password.ToString()))
            {
                MessageBox.Show("لطفا نام کاربری خود را وارد کنید.");
                return;
            }

            currentUser = new Users(1, name,123);
            tabControl1.SelectedTab = tabPage2; // Move to quiz page
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            tabPage2.Controls.Clear();

            if (currentIndex >= questions.Count)
            {
                tabControl1.SelectedTab = tabPage3;
                lbl_result.Text = $"{currentUser.UserName} جان، نمره شما: {score} از {questions.Count}";
                return;
            }

            var q = questions[currentIndex];

            Label lblQuestion = new Label
            {
                Text = q.Text,
                Top = 30,
                Left = 30,
                Width = 400,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            tabPage2.Controls.Add(lblQuestion);

            for (int i = 0; i < q.Options.Length; i++)
            {
                Button btn = new Button
                {
                    Text = q.Options[i],
                    Width = 200,
                    Height = 40,
                    Left = 30,
                    Top = 80 + (i * 50),
                    Tag = i
                };
                btn.Click += btn_Option_Click;
                tabPage2.Controls.Add(btn);
            }
        }

        private void btn_Option_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            int selectedIndex = (int)clicked.Tag;

            if (selectedIndex == questions[currentIndex].CorrectIndex)
            {
                score++;
            }

            currentIndex++;
            ShowQuestion();
        }
    }



}

