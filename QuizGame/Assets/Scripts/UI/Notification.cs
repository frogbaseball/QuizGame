using UnityEngine;
namespace UI {
    public class Notification : MonoBehaviour {
        public void OnPressDestroy() {
            Destroy(gameObject);
        }
    }
}