using QuestionManagement;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UI {
    namespace JSONCreation { 
        public class PickQuestionOnClick : MonoBehaviour, IPointerClickHandler {
            private QuestionVisualizer _questionVisualizer;
            private Question _questionAssociated;
            public QuestionVisualizer QuestionVisualizer { get { return _questionVisualizer; } set { _questionVisualizer = value; } }
            public Question QuestionAssociated { get { return _questionAssociated; } set { _questionAssociated = value; } }
            public void OnPointerClick(PointerEventData eventData) {
                _questionVisualizer.PickedQuestion = _questionAssociated;
                _questionVisualizer.VisualizePickedQuestion();
            }
        }
    }
}