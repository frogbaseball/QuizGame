using UnityEngine;
using UnityEngine.SceneManagement;
namespace SceneManagement {
    public class SceneChanger : MonoBehaviour {
        public static void ChangeScene(int index) {
            SceneManager.LoadScene(index);
        }
        public static void ChangeScene(string name) {
            SceneManager.LoadScene(name);
        }
    }
}