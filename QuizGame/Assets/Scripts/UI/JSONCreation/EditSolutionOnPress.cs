using UnityEngine;
using UnityEngine.EventSystems;
namespace UI {
    namespace JSONCreation {
        public class EditSolutionOnPress : MonoBehaviour, IPointerClickHandler {
            [SerializeField] private GameObject _editTextPopupPrefab;
            [Header("Scripts")]
            [SerializeField] private QuestionUpdater _questionUpdater;
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            [Header("Edit Text Popup Settings")]
            [SerializeField] private Transform _parent;
            public void OnPointerClick(PointerEventData eventData) {
                var etp = Instantiate(_editTextPopupPrefab, _parent.position, Quaternion.identity, _parent);
                etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionUpdater.ChangeSolutionText(); });
                etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionVisualizer.VisualizePickedQuestion(); });
            }
        }
    }
}