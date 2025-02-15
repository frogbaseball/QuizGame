using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI {
    namespace JSONCreation {
        public class CloseOpenSettings : MonoBehaviour {
            public void OpenCloseSettings() {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
}