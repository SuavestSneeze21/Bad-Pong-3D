using UnityEngine;

namespace Manager
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField] float speed = 15f;
        [SerializeField] float limitY = 7.5f;
        [SerializeField] Transform ball;

        Vector3 move;

        // Update is called once per frame
        void Update()
        {
            float d = ball.position.y - transform.position.y;

            if (d > 0)
            {
                move.y = speed * Mathf.Min(d, 40);
            }
            if (d < 0)
            {
                move.y = -speed * Mathf.Min(-d, 40);
            }

            float movement = move.y * speed * Time.deltaTime;

            transform.position += transform.up * movement;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -limitY, limitY), transform.position.z);
        }
    }
}
