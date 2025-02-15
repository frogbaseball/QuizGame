using System.Collections;
using System.Collections.Generic;
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

