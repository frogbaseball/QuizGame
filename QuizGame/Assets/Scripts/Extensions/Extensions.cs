using UnityEngine;
namespace Extensions {
    public static class Extensions {
        public static void MurderAllChildren(this Transform transform) {
            for (int i = 0; i < transform.childCount; i++) {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}