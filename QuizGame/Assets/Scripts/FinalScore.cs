using QuestionManagement;
using TMPro;
using UnityEngine;
namespace UI {
    namespace JSONPlay {
        public class FinalScore : MonoBehaviour {
            [Header("Components")]
            [SerializeField] private TextMeshProUGUI scoreText;
            [Header("Scripts")]
            [SerializeField] private QuestionMover questionMover;
            [SerializeField] private JSONQuestionLoader jsonQuestionLoader;
            public void UpdateScore() {
                scoreText.text = $"Your final score:\n{ReturnScore()}/{ReturnMaxScore()}\nGood job!";
            }
            private int ReturnScore() {
                int score = 0;
                for (int i = 0; i < jsonQuestionLoader.Questions.Count; i++) {
                    for (int j = 0; j < jsonQuestionLoader.Questions[i].Solutions.Length; j++) {
                        if (questionMover.PickedSolutionsInOrder[i] == j &&
                            jsonQuestionLoader.Questions[i].Solutions[j].IsCorrect == true) {
                            score++;
                        }
                    }
                }
                return score;
            }
            private int ReturnMaxScore() {
                return jsonQuestionLoader.Questions.Count;
            }
        }
    }
}