using Enemy;
using UnityEngine;

namespace Player.PlayerInput
{
    public class EnemySeeker : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyLayerMask;

        public EnemyHealth CurrentEnemyHealth { get; private set; }

        private void Update()
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity, _enemyLayerMask);

            if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentEnemyHealth = hit.collider.GetComponent<EnemyHealth>();
                }
            }
        }
    }
}