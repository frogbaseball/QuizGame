using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QuestionManagement {
    public class QuestionCreator : MonoBehaviour {
        private List<Question> _questions = new List<Question>();
        public List<Question> Questions { get { return _questions; } set { _questions = value; } }
        public void CreateQuestion(string name, string problem, Solution[] solutions) {
            _questions.Add(new Question(name, problem, solutions));
        }
        public void RemoveQuestion(Question question) {
            _questions.Remove(question);
        }
    }
}