using UnityEngine;

namespace Assets.Source.Core.Utils
{
    public class PrefabManager
    {
        public static GameObject Generate(string name, string path, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            string prefabPath = $"Prefabs/{path}/{name}";

            rotation.Normalize();

            return Object.Instantiate(Resources.Load<GameObject>(prefabPath), position, rotation, parent);
        }
    }
}
