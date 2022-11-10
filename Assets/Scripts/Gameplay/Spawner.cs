using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] Buffs;
        public Transform[] Spwaners;

        public GameObject Player1;
        public GameObject Player2;

        void Awake()
        {
            Game thisGame = Database.Games[^1];

            Player1.name = thisGame.Player1.Name;
            Player1.GetComponent<SpriteRenderer>().sprite = Database.ShipSprites.Where(x => x.name.Equals(thisGame.Player1.Ship)).First();
            Player1.GetComponent<Weapon>().C = thisGame.Player1.Color;

            Player2.name = thisGame.Player2.Name;
            Player2.GetComponent<SpriteRenderer>().sprite = Database.ShipSprites.Where(x => x.name.Equals(thisGame.Player2.Ship)).First();
            Player2.GetComponent<Weapon>().C = thisGame.Player2.Color;

            thisGame.T = GameObject.Find("TimerText").GetComponent<Timer>();

            StartCoroutine(SpawnBuffs());

        }

        public void EndGame()
        {
            Database.Games[^1].p1 = Player1.GetComponent<PlayerConroller>();
            Database.Games[^1].p2 = Player2.GetComponent<PlayerConroller>();
            Database.Games[^1].EndGame();
        }

        private IEnumerator SpawnBuffs()
        {
            yield return new WaitForSeconds(3f);
            while (true)
            {
                if (Spwaners[1].childCount == 0 && Spwaners[2].childCount == 0)
                {
                    int random = 0;
                    while (random == 0)
                    {
                        random = Random.Range(0, Spwaners.Length);
                    }
                    Instantiate(Buffs[Random.Range(0, Buffs.Length)], Spwaners[random]);
                }
                else
                if (Spwaners[0].childCount == 0 && Spwaners[2].childCount == 0)
                {
                    int random = 1;
                    while (random == 1)
                    {
                        random = Random.Range(0, Spwaners.Length);
                    }
                    Instantiate(Buffs[Random.Range(0, Buffs.Length)], Spwaners[random]);
                }
                else
                if (Spwaners[0].childCount == 0 && Spwaners[1].childCount == 0)
                {
                    int random = 2;
                    while (random == 2)
                    {
                        random = Random.Range(0, Spwaners.Length);
                    }
                    Instantiate(Buffs[Random.Range(0, Buffs.Length)], Spwaners[random]);
                }


                yield return new WaitForSeconds(Random.Range(15, 20));
            }
        }
    }
}
