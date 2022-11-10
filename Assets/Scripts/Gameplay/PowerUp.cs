using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PowerUp : MonoBehaviour
    {
        private GameObject Player1;
        private GameObject Player2;

        public int BuffNumber;
        public float speedUp;
        public float speedDown;

        void Awake()
        {
            Player1 = transform.parent.parent.GetComponent<Spawner>().Player1;
            Player2 = transform.parent.parent.GetComponent<Spawner>().Player2;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            try
            {

                if (other.GetComponent<Bullet>().Tag == "1")
                {

                    StartCoroutine(Pickup(Player1));
                }
                else if (other.GetComponent<Bullet>().Tag == "2")
                {
                    StartCoroutine(Pickup(Player2));
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public IEnumerator Pickup(GameObject Player)
        {
            if (BuffNumber == 1)
                Player.GetComponent<Weapon>().SpeedUp(5);
            if (BuffNumber == 2)
                Player.GetComponent<Weapon>().SpeedDown(10);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(5f);
            if (BuffNumber == 1)
                Player.GetComponent<Weapon>().SpeedDown(5);
            if (BuffNumber == 2)
                Player.GetComponent<Weapon>().SpeedUp(10); ;
            Destroy(gameObject);
        }
    }
}
