using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UI.JSONCreation;
using UnityEngine;
using UnityEngine.EventSystems;
public class EditExplanationOnPress : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject _editTextPopupPrefab;
    [Header("Scripts")]
    [SerializeField] private QuestionUpdater _questionUpdater;
    [SerializeField] private QuestionVisualizer _questionVisualizer;
    [Header("Edit Text Popup Settings")]
    [SerializeField] private Transform _parent;
    public void OnPointerClick(PointerEventData eventData) {
        var etp = Instantiate(_editTextPopupPrefab, _parent.position, Quaternion.identity, _parent);
        etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(_questionUpdater.ChangeExplanationText);
        etp.GetComponent<EditTextPopup>().OnSavePress.AddListener(UpdateText);
    }
    public void UpdateText() {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = $"Explanation {_questionUpdater.Index + 1}: {_questionVisualizer.PickedQuestion.Solutions[_questionUpdater.Index].Explanation}";
    }
}