using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CloseOpenSettings : MonoBehaviour {
    [SerializeField] private GameObject _settings;
    private void Start() {
        _settings.SetActive(false);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OpenCloseSettings();
        }
    }
    public void OpenCloseSettings() {
        _settings.SetActive(!_settings.activeSelf);
    }
}