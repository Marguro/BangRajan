using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
                Debug.Log("Hit Wall");
            }
        }
        
    }
}