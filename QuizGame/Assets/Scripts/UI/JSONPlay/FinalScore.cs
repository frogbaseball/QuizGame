using QuestionManagement;
using TMPro;
using UnityEngine;
namespace UI {
    namespace JSONPlay {
        public class FinalScore : MonoBehaviour {
            [Header("Components")]
            [SerializeField] private TextMeshProUGUI _scoreText;
            [Header("Scripts")]
            [SerializeField] private QuestionMover _questionMover;
            [SerializeField] private JSONQuestionLoader _jsonQuestionLoader;
            public void UpdateText() {
                _scoreText.text = $"Your final score:\n{GainedScore()}/{MaxScore()}\nGood job!";
            }
            private int GainedScore() {
                int score = 0;
                for (int i = 0; i < _jsonQuestionLoader.Questions.Count; i++) {
                    for (int j = 0; j < _jsonQuestionLoader.Questions[i].Solutions.Length; j++) {
                        if (_questionMover.PickedSolutionsInOrder[i] == j &&
                            _jsonQuestionLoader.Questions[i].Solutions[j].IsCorrect == true) {
                            score++;
                        }
                    }
                }
                return score;
            }
            private int MaxScore() {
                return _jsonQuestionLoader.Questions.Count;
            }
        }
    }
}