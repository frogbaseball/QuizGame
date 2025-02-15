using QuestionManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace UI {
    namespace JSONPlay {
        public class QuestionMover : MonoBehaviour {
            [Header("Scripts")]
            [SerializeField] private JSONQuestionLoader _jsonQuestionLoader;
            [SerializeField] private FinalScore _finalScore;
            [Header("Components")]
            [SerializeField] private GameObject[] _solutions;
            [SerializeField] private TextMeshProUGUI _problemText;
            [SerializeField] private TextMeshProUGUI _explanationText;
            [SerializeField] private Button _nextButton;
            [Header("For End Game")]
            [SerializeField] private Transform _toTurnOff;
            [SerializeField] private Transform _toTurnOn;
            [Header("Colors")]
            [SerializeField] private Color _defaultColor;
            [SerializeField] private Color _pickedColor;
            [SerializeField] private Color _notPickedColor;
            private int[] _pickedSolutionsInOrder;
            private int _currentQuestionIndex = 0;
            private bool _hasAlreadyPickedAnAnswerOnCurrentQuestion = false;
            public int[] PickedSolutionsInOrder { get {  return _pickedSolutionsInOrder; } }
            private void Start() {
                _pickedSolutionsInOrder = new int[_jsonQuestionLoader.Questions.Count];
                VisualizeQuestion();
            }
            public void OnSolutionButtonPress(int btnNumber) {
                if (_hasAlreadyPickedAnAnswerOnCurrentQuestion)
                    return;
                _pickedSolutionsInOrder[_currentQuestionIndex] = btnNumber;
                _hasAlreadyPickedAnAnswerOnCurrentQuestion = true;
                ShowNextButton();
                ShowAnswersAndExplanation();
            }
            private void MoveToNextQuestion() {
                _currentQuestionIndex++;
                VisualizeQuestion();
            }
            private void EndGame() {
                _toTurnOff.gameObject.SetActive(false);
                _toTurnOn.gameObject.SetActive(true);
                _finalScore.UpdateText();
            }
            private void ShowNextButton() {
                _nextButton.gameObject.SetActive(true);
            }
            private void HideNextButton() {
                _nextButton.gameObject.SetActive(false);
            }
            private void ShowExplanation() {
                _explanationText.gameObject.SetActive(true);
            }
            private void HideExplanation() {
                _explanationText.gameObject.SetActive(false);
            }
            public void OnNextButtonPress() {
                _hasAlreadyPickedAnAnswerOnCurrentQuestion = false;
                if (_currentQuestionIndex + 1 > _jsonQuestionLoader.Questions.Count - 1) {
                    EndGame();
                    return;
                }
                MoveToNextQuestion();
                HideNextButton();
                HideAnswersAndExplanation();
            }
            private void ShowAnswersAndExplanation() {
                ShowExplanation();
                _explanationText.text = _jsonQuestionLoader.Questions[_currentQuestionIndex].Solutions[_pickedSolutionsInOrder[_currentQuestionIndex]].Explanation;
                for (int i = 0; i < _solutions.Length; i++) {
                    _solutions[i].GetComponent<Outline>().enabled = true;
                    _solutions[i].GetComponent<Outline>().effectColor = _jsonQuestionLoader.Questions[_currentQuestionIndex].Solutions[i].IsCorrect ? Color.green : Color.red;
                    if (i != _pickedSolutionsInOrder[_currentQuestionIndex]) {
                        _solutions[i].GetComponentInChildren<Image>().color = _notPickedColor;
                    } else {
                        _solutions[i].GetComponentInChildren<Image>().color = _pickedColor;
                    }
                }
            }
            private void HideAnswersAndExplanation() {
                HideExplanation();
                for (int i = 0; i < _solutions.Length; i++) {
                    _solutions[i].GetComponent<Outline>().enabled = false;
                    _solutions[i].GetComponent<Image>().color = _defaultColor;
                }
            }
            private void VisualizeQuestion() {
                _problemText.text = $"{_jsonQuestionLoader.Questions[_currentQuestionIndex].Name} \n\n {_jsonQuestionLoader.Questions[_currentQuestionIndex].Problem}";
                for (int i = 0; i < _solutions.Length; i++) {
                    _solutions[i].GetComponentInChildren<TextMeshProUGUI>().text = _jsonQuestionLoader.Questions[_currentQuestionIndex].Solutions[i].SolutionText;
                }
            }
        }
    }
}