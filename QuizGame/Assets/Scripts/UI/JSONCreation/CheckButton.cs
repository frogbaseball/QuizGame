using QuestionManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace UI {
    namespace JSONCreation {
        public class CheckButton : MonoBehaviour {
            private TextMeshProUGUI _text;
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            [SerializeField] private int _index;
            private void Start() {
                _text = GetComponentInChildren<TextMeshProUGUI>();
            }
            public void OnPress() {
                if (_text.text == "T") {
                    _text.text = "F";
                    _questionVisualizer.PickedQuestion.Solutions[_index].IsCorrect = false;
                } else {
                    _text.text = "T";
                    _questionVisualizer.PickedQuestion.Solutions[_index].IsCorrect = true;
                }
            }
        }
    }
}
