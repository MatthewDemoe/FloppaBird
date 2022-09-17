using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class StartupActionsRunner : MonoBehaviour
    {
        private static bool FirstRun = true;

        [SerializeField]
        List<GameObject> prefabsToLoad = new List<GameObject>();

        void Awake()
        {
            if (!FirstRun)
            {
                Destroy(gameObject);
                return;
            }

            FirstRun = false;
            DontDestroyOnLoad(gameObject);

            prefabsToLoad.ForEach(prefab => Instantiate(prefab));
        }
    }
}