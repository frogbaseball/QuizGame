using QuestionManagement;
using TMPro;
using UnityEngine;
namespace UI {
    namespace JSONPlay {
        public class QuestionMover : MonoBehaviour {
            [Header("Scripts")]
            [SerializeField] private JSONQuestionLoader jsonQuestionLoader;
            [SerializeField] private FinalScore finalScore;
            [Header("Components")]
            [SerializeField] private GameObject[] solutions;
            [SerializeField] private TextMeshProUGUI problemText;
            [Header("For End Game")]
            [SerializeField] private Transform toTurnOff;
            [SerializeField] private Transform toTurnOn;
            private int[] pickedSolutionsInOrder;
            private int currentQuestionIndex = 0;
            public int[] PickedSolutionsInOrder { get {  return pickedSolutionsInOrder; } }
            private void Start() {
                pickedSolutionsInOrder = new int[jsonQuestionLoader.Questions.Count];
                VisualizeQuestion();
            }
            public void OnSolutionButtonPress(int btnNumber) {
                pickedSolutionsInOrder[currentQuestionIndex] = btnNumber;
                if (currentQuestionIndex + 1 > jsonQuestionLoader.Questions.Count - 1) {
                    EndGame();
                    return;
                }               
                MoveToNextQuestion();
            }
            private void MoveToNextQuestion() {
                currentQuestionIndex++;
                VisualizeQuestion();
            }
            private void EndGame() {
                toTurnOff.gameObject.SetActive(false);
                toTurnOn.gameObject.SetActive(true);
                finalScore.UpdateScore();
            }
            private void VisualizeQuestion() {
                problemText.text = $"{jsonQuestionLoader.Questions[currentQuestionIndex].Name} \n\n {jsonQuestionLoader.Questions[currentQuestionIndex].Problem}";
                for (int i = 0; i < solutions.Length; i++) {
                    solutions[i].GetComponentInChildren<TextMeshProUGUI>().text = jsonQuestionLoader.Questions[currentQuestionIndex].Solutions[i].SolutionText;
                }
            }
        }
    }
}