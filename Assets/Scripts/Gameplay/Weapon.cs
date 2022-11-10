using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public float FireRate = 3;
        public float lastfired;
        public GameObject Bullet;
        public Sprite[] Sprites;
        public string trigger;
        public string C;
        public string BuliitTag;
        public float Speed = 20f;
        public AudioSource Shootsound;


        void Update()
        {
            if (Input.GetButtonDown(trigger) && Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }


        void Shoot()
        {
            Shootsound.Play();
            InstantiateBullet(Instantiate(Bullet, firePoint.position, firePoint.rotation), BuliitTag, Speed);

        }
        public void SpeedUp(float s)
        {
            Speed += s;
        }
        public void SpeedDown(float s)
        {
            Speed -= s;
        }

        public void InstantiateBullet(GameObject bullit, string tag, float speed)
        {
            bullit.GetComponent<Bullet>().Tag = tag;
            bullit.GetComponent<Bullet>().speed = Speed;
            bullit.GetComponent<SpriteRenderer>().sprite = Database.BullitSprites.Where(x => x.name.Equals(C)).First();
        }

    }
}
