using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_app_project
{
    public class Question
    {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectIndex { get; set; }

            public Question(string text, string[] options, int correctIndex)
            {
                Text = text;
                Options = options;
                CorrectIndex = correctIndex;
            }
        

    }
}
