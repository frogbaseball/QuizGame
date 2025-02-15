using System.Collections;
using System.Collections.Generic;
using UI;
using UI.JSONCreation;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UI {
    namespace JSONCreation {
        public class EditProblemOnPress : MonoBehaviour, IPointerClickHandler {
            [SerializeField] private GameObject _editTextPopupPrefab;
            [Header("Scripts")]
            [SerializeField] private QuestionUpdater _questionUpdater;
            [SerializeField] private QuestionVisualizer _questionVisualizer;
            [Header("Edit Text Popup Settings")]
            [SerializeField] private Transform _parent;
            public void OnPointerClick(PointerEventData eventData) {
                var etp = Instantiate(_editTextPopupPrefab, _parent.position, Quaternion.identity, _parent);
                etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionUpdater.ChangeProblemText(); });
                etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(delegate { _questionVisualizer.VisualizePickedQuestion(); });
            }
        }
    }
}