using UnityEngine;
using UnityEngine.EventSystems;
namespace UI { 
    namespace JSONCreation {
        public class EditOnPress : MonoBehaviour, IPointerClickHandler {
            [SerializeField] private GameObject _editTextPopupPrefab;
            [Header("Scripts")]
            [SerializeField] private QuestionUpdater _questionUpdater;
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            [Header("Edit Text Popup Settings")]
            [SerializeField] private Transform _parent;
            [SerializeField] private bool isSolution = false;
            public void OnPointerClick(PointerEventData eventData) {
                var etp = Instantiate(_editTextPopupPrefab, _parent.position, Quaternion.identity, _parent);
                if (!isSolution) {
                    etp.GetComponent<EditTextPopup>().OnSavePress.AddListener( delegate { _questionUpdater.ChangeProblemText(); } );
                    etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionVisualizer.VisualizePickedQuestion(); });
                } else {
                    etp.GetComponent<EditTextPopup>().OnSavePress.AddListener( delegate { _questionUpdater.ChangeSolutionText(); });
                    etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionVisualizer.VisualizePickedQuestion(); });
                }
            }
        }
    }
}