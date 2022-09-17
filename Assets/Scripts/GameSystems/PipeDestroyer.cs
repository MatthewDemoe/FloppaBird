using Identifiers;
using UnityEngine;

namespace GameSystems
{
    public class PipeDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Obstacle)
                Destroy(collision.gameObject);

            
        }
    }
}