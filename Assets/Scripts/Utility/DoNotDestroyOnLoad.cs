using UnityEngine;

namespace Utility
{
    public class DoNotDestroyOnLoad : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}