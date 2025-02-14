using QuestionManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using Newtonsoft.Json;
namespace UI { 
    namespace JSONCreation {
        public class JSONConverter : MonoBehaviour {
            [SerializeField] private QuestionCreator _questionCreator;
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            public void ConvertToJSON() {
                string data = JsonConvert.SerializeObject(_questionCreator.Questions, Formatting.Indented);
                StartCoroutine(SaveFileCoroutine(data));
            }
            private IEnumerator SaveFileCoroutine(string data) {
                FileBrowser.SetFilters(false, new FileBrowser.Filter("json", ".json"));
                FileBrowser.SetDefaultFilter(".json");
                yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.Files, false);
                if (FileBrowser.Success) {
                    string[] paths = FileBrowser.Result;
                    FileBrowserHelpers.WriteTextToFile(paths[0], data);
                }
            }
            public void ConvertFromJSON() {
                StartCoroutine(LoadFileCoroutine());
            }
            private IEnumerator LoadFileCoroutine() {
                FileBrowser.SetFilters(false, new FileBrowser.Filter("json", ".json"));
                FileBrowser.SetDefaultFilter(".json");
                yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false);
                if (FileBrowser.Success) {
                    string[] paths = FileBrowser.Result;
                    string data = FileBrowserHelpers.ReadTextFromFile(paths[0]);
                    _questionCreator.Questions = JsonConvert.DeserializeObject<List<Question>>(data);
                    _questionVisualizer.VisualizeQuestions();
                    _questionVisualizer.PickedQuestion = _questionCreator.Questions[0];
                    _questionVisualizer.VisualizePickedQuestion();
                }
            }
        }
    }
}