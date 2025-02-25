using UnityEngine;
namespace UI {
    namespace JSONCreation {
        public class QuestionUpdater : MonoBehaviour {
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            [SerializeField] private int _index;
            public int Index { get { return _index; } }
            public void ChangeSolutionText() {
                _questionVisualizer.PickedQuestion.Solutions[_index].SolutionText = EditTextPopup.Text;
            }
            public void ChangeProblemText() {
                _questionVisualizer.PickedQuestion.Problem = EditTextPopup.Text;
            }
            public void ChangeExplanationText() {
                _questionVisualizer.PickedQuestion.Solutions[_index].Explanation = EditTextPopup.Text;
            }
        }
    }
}