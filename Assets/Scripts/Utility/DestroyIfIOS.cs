using UnityEngine;

public class DestroyIfIOS : MonoBehaviour
{
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            Destroy(gameObject);
    }
}
