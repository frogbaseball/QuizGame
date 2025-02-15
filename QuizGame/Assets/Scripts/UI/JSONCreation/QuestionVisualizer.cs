using UnityEngine;
using UnityEngine.UI;
using Extensions;
using TMPro;
using QuestionManagement;
namespace UI {
    namespace JSONCreation {
        public class QuestionVisualizer : MonoBehaviour {
            private QuestionCreator _questionCreator;
            private Question _pickedQuestion;
            [Header("Questions Settings")]
            [SerializeField] private Transform _questionsGroup;
            [SerializeField] private GameObject _questionPrefab;
            [SerializeField] private GameObject _createQuestionPrefab;
            [Header("Picked Question Settings")]
            [SerializeField] private TextMeshProUGUI _questionText;
            [SerializeField] private GameObject[] _solutionObjects;
            public Question PickedQuestion { get { return _pickedQuestion; } set { _pickedQuestion = value; } }
            private void Start() {
                _questionCreator = GetComponent<QuestionCreator>();
                CreateQuestion();
                VisualizeQuestions();
                _pickedQuestion = _questionCreator.Questions[0];
                VisualizePickedQuestion();
            }
            public void VisualizeQuestions() {
                _questionsGroup.MurderAllChildren();
                foreach (Question question in _questionCreator.Questions) {
                    var q = Instantiate(_questionPrefab, transform.position, Quaternion.identity, _questionsGroup);
                    q.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnPressX(question); } );
                    q.GetComponentInChildren<TextMeshProUGUI>().text = $"{question.Name} \n\n {question.Problem}";
                    q.GetComponentInChildren<TextMeshProUGUI>().GetComponent<PickQuestionOnClick>().QuestionAssociated = question;
                    q.GetComponentInChildren<TextMeshProUGUI>().GetComponent<PickQuestionOnClick>().QuestionVisualizer = this;
                }
                CreateButtonForCreatingMoreQuestions();
            }
            private void OnPressX(Question question) {
                _questionCreator.RemoveQuestion(question);
                VisualizeQuestions();
            }
            private void CreateButtonForCreatingMoreQuestions() {
                var btn = Instantiate(_createQuestionPrefab, transform.position, Quaternion.identity, _questionsGroup);
                btn.GetComponentInChildren<Button>().onClick.AddListener(delegate { CreateQuestion(); });
            }
            private void CreateQuestion() {
                var solutions = new Solution[] {
                    new Solution("A", true, "the letter 'a' is the first letter of the alphabet."),
                    new Solution("B", false, "the letter 'b' is the second letter of the alphabet."),
                    new Solution("C", false, "the letter 'c' is the third letter of the alphabet."),
                    new Solution("D", false, "the letter 'd' is the fourth letter of the alphabet.")
                };
                _questionCreator.CreateQuestion($"Question {_questionCreator.Questions.Count + 1}", "What is the first letter of the alphabet?", solutions);
                VisualizeQuestions();
            }
            public void VisualizePickedQuestion() {
                _questionText.text = $"{_pickedQuestion.Name} \n\n {_pickedQuestion.Problem}";
                for (int i = 0; i < _solutionObjects.Length; i++) {
                    _solutionObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = _pickedQuestion.Solutions[i].SolutionText;
                    _solutionObjects[i].GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = _pickedQuestion.Solutions[i].IsCorrect ? "T" : "F";
                }
            }
        }
    }
}