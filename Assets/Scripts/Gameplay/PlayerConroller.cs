using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{

    public class PlayerConroller : MonoBehaviour
    {
        private string _MovementAxisName = "Vertical";
        private Vector2 _Movement;

        public int PlayerNumber;
        public float Speed = 7f;
        public Rigidbody2D Rigidbody;
        public int Health = 100;
        public int MaxHealth = 100;
        public GameObject healthGUI;
        public AudioSource Damgesound;
        public AudioSource Explodesound;
        public Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
            _MovementAxisName += PlayerNumber;
            Rigidbody = GetComponent<Rigidbody2D>();
            GetComponent<Weapon>().trigger = "Fire_" + PlayerNumber;
            GetComponent<Weapon>().BuliitTag = $"{PlayerNumber}";
            healthGUI = GameObject.Find("HealthBar" + PlayerNumber);
            healthGUI.GetComponent<HealthBar>().MaxHealth(MaxHealth);

        }

        void Update()
        {
            _Movement.y = Input.GetAxisRaw(_MovementAxisName);
        }

        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Rigidbody.MovePosition(Rigidbody.position + _Movement * Speed * Time.fixedDeltaTime);
        }

        private IEnumerator Explode()
        {
            GameObject.Find("Spawner").GetComponent<Spawner>().EndGame();
            animator.enabled = true;
            animator.SetBool("explode", true);
            yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene("EndGameScreen");
        }
        public void Damage(int dmg)
        {
            Damgesound.Play();
            if (Health <= dmg)
            {

                Health = 0;
                healthGUI.GetComponent<HealthBar>().SetHealth(0);
                Explodesound.Play();
                StartCoroutine(Explode());
                return;
            }
            Health -= dmg;
            healthGUI.GetComponent<HealthBar>().SetHealth(Health);
        }
    }


}


