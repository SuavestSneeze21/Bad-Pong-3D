using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 15f;
        [SerializeField] float limitY = 7.5f;
        [SerializeField] bool useVertical2;

        // Update is called once per frame
        void Update()
        {
            float vertical;

            if (useVertical2)
                vertical = Input.GetAxisRaw("Vertical2");
            else
                vertical = Input.GetAxisRaw("Vertical");

            float movement = vertical * speed * Time.deltaTime;

            transform.position += transform.up * movement;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -limitY, limitY), transform.position.z);
        }
    }
}
