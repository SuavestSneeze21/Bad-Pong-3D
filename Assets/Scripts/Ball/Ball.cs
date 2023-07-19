using Manager;
using UnityEngine;
using System.Collections;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        Rigidbody body;

        Vector3 randomForce;
        Vector3 startingPoint;

        bool done;

        [SerializeField] float initialStrength = 10f;
        [SerializeField] float hitStrength = 2f;
        [SerializeField] float maxForce = 2f;

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody>();
            startingPoint = transform.position;

            StartGame();
        }

        void StartGame()
        {
            int random = Random.Range(0, 2);

            if (random == 0)
                randomForce = -transform.right;
            else
                randomForce = transform.right;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!done)
            {
                body.AddForce(randomForce * initialStrength, ForceMode.Impulse);
                done = true;
            }

            body.velocity = Vector3.ClampMagnitude(body.velocity, maxForce);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                ContactPoint contact = collision.contacts[0];

                body.AddForce(-contact.point * hitStrength + transform.up * Random.Range(5, 15), ForceMode.Impulse);

                StopAllCoroutines();
                StartCoroutine(ResetBall());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Goal"))
            {
                transform.position = startingPoint;
                body.velocity = Vector3.zero;

                done = false;
                StartGame();

                GoalManager goal = other.GetComponent(typeof(GoalManager)) as GoalManager;
                if (goal)
                {
                    goal.AddScore();
                }
            }
        }

        IEnumerator ResetBall()
        {
            yield return new WaitForSeconds(10);

            done = false;
            StartGame();
        }
    }
}
