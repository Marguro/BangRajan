using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header(" Element ")]
        private Wall _wall;
        
        [Header(" Settings ")]
        [SerializeField] private float moveSpeed;
        private Vector2 _targetPoint;
        
        private void Start()
        {
            //Find Wall GameObject and BoxCollider
            _wall = FindAnyObjectByType<Wall>() ;
            BoxCollider2D wallCollider = _wall.GetComponent<BoxCollider2D>();

            Vector2 wallCenter = wallCollider.bounds.center;
            Vector2 wallSize = wallCollider.bounds.size;

            float randomX = UnityEngine.Random.Range(-wallSize.x / 2, wallSize.x / 2);
            float randomY = UnityEngine.Random.Range(-wallSize.y / 2, wallSize.y / 2);
            _targetPoint = wallCenter + new Vector2(randomX, randomY);
        }
        
        private void Update()
        {
            if (_wall != null)
                Move();
        }

        private void Move()
        {
            Vector2 direction = (_targetPoint - (Vector2)transform.position).normalized;
            Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
            transform.position = targetPosition;
        }
        
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