using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody2D rb;
        public string Tag;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * speed;
        }

        // Update is called once per frame
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            PlayerConroller p = hitInfo.GetComponent<PlayerConroller>();
            if (p != null)
            {
                p.Damage(10);
            }
            Destroy(gameObject);
        }

    }
}
