using System;
namespace QuestionManagement {
    public class Question {
        private string _name;
        private string _problem;
        private Solution[] _solutions;
        public Solution[] Solutions { get { return _solutions; } set { _solutions = value; } }
        public string Problem { get { return _problem; } set { _problem = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public Question(string name, string problem, Solution[] solutions) {
            if (solutions.Length > 4 || solutions.Length < 4) {
                throw new ArgumentException("Solutions count cannot be lower or higher than 4");
            }
            _solutions = solutions;
            _problem = problem;
            _name = name;
        }
    }
    public class Solution {
        private string _solutionText;
        private bool _isCorrect;
        private string _explanation;
        public string SolutionText { get { return _solutionText; } set { _solutionText = value; } }
        public bool IsCorrect { get { return _isCorrect; } set { _isCorrect = value; } }
        public string Explanation { get { return _explanation; } set { _explanation = value; } }
        public Solution(string solutionText, bool isCorrect, string explanation) {
            _solutionText = solutionText;
            _isCorrect = isCorrect;
            _explanation = explanation;
        }
    }
}