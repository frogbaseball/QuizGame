using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UI.JSONPlay;
using SimpleFileBrowser;
namespace QuestionManagement {
    public class JSONQuestionLoader : MonoBehaviour {
        private List<Question> _questions = new List<Question>();
        public List<Question> Questions { get { return _questions; } set { _questions = value; } }
        private void Awake() {
            LoadQuestions();
        }
        public void LoadQuestions() {
            string data = FileBrowserHelpers.ReadTextFromFile(StartJSONGame.Path);
            _questions = JsonConvert.DeserializeObject<List<Question>>(data);
        }
    }
}