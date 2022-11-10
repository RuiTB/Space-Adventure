using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game
    {
        public Profile Player1 { private set; get; }
        public Profile Player2 { private set; get; }

        public string Winner { private set; get; }

        public DateTime Date { private set; get; }

        public int Score { private set; get; }
        public long Duration { private set; get; }

        public Timer T { set; get; }

        public PlayerConroller p1 { set; get; }
        public PlayerConroller p2 { set; get; }

        public long ID { private set; get; }

        public Game(Profile player1, Profile player2, long id)
        {
            Player1 = player1;
            Player2 = player2;
            ID = id;
        }

        public void EndGame()
        {
            CalculateScore();
            WhoIsTheWinner();
            CalculateDuration();
            Date = DateTime.Now;
        }

        public void CalculateScore()
        {
            int s1 = 0, s2 = 0;

            s2 = (100 - p1.Health) / 10;
            s1 = (100 - p2.Health) / 10;

            Score = Math.Max(s1, s2);
        }

        public void WhoIsTheWinner()
        {
            if (p1.Health > p2.Health)
            {
                Winner = Player1.Name;
            }
            else if (p1.Health < p2.Health)
            {
                Winner = Player2.Name;
            }
            else
            {
                Winner = "TIE";
            }
        }

        public void CalculateDuration()
        {
            Duration = 120 - (int)T.timeRemaining;
        }

        public void Replay()
        {
            Debug.Log("Replay Started " + ID);
        }
    }
}