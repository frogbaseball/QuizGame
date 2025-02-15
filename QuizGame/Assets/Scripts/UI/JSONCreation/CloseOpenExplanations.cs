using UnityEngine;
namespace UI {
    namespace JSONCreation {
        public class CloseOpenExplanations : MonoBehaviour {
            public void OpenCloseExplanations() {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
}

