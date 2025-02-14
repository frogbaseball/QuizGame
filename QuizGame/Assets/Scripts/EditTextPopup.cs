using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
namespace UI {
    public class EditTextPopup : MonoBehaviour {
        [SerializeField] private TMP_InputField _input;
        public UnityEvent OnSavePress = new UnityEvent();
        public static string Text;
        public void Save() {
            OnSavePress.Invoke();
            DestroyPopup();
        }
        public void OnInputChange() {
            Text = _input.text;
        }
        public void DestroyPopup() {
            Destroy(gameObject);
        }
    }
}