using SceneManagement;
using SimpleFileBrowser;
using System.Collections;
using TMPro;
using UnityEngine;
namespace UI {
    namespace JSONPlay {
        public class StartJSONGame : MonoBehaviour {
            public static string Path;
            [SerializeField] private GameObject _notificationPrefab;
            [SerializeField] private Transform _parent;
            public void OnButtonPress() {
                StartCoroutine(LoadFileCoroutine());
            }
            private IEnumerator LoadFileCoroutine() {
                FileBrowser.SetFilters(false, new FileBrowser.Filter("json", ".json"));
                FileBrowser.SetDefaultFilter(".json");
                yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false);
                if (FileBrowser.Success) {
                    string[] paths = FileBrowser.Result;
                    Path = paths[0];
                    SceneChanger.ChangeScene("Game");
                } else {
                    var ntf = Instantiate(_notificationPrefab, _parent.transform.position, Quaternion.identity, _parent);
                    ntf.GetComponentInChildren<TextMeshProUGUI>().text = "There was an error!";
                }
            }
        }
    }
}