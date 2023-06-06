using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            player1.Play(large);

            Console.WriteLine("-------------------");

            Player player4 = new SmackTalkingPlayer("Are you scared yet?");
            player4.Name = "John";

            player4.Play(large);

            Console.WriteLine("-------------------");

            Player player5 = new OneHigherPlayer();
            player5.Name = "Winner";

            player5.Play(player2);

            Console.WriteLine("-------------------");

            Player player6 = new HumanPlayer();
            player6.Name = "Cheater";

            player6.Play(player4);

            Console.WriteLine("-------------------");


            Player player7 = new CreativeSmackTalkingPlayer();
            player7.Name = "Funny Guy";

            player7.Play(player1);

            Console.WriteLine("-------------------");

            Player player8 = new SoreLoserPlayer();
            player8.Name = "Loser";

            player8.Play(player1);

            Console.WriteLine("-------------------");

            Player player9 = new UpperHalfPlayer();
            player9.Name = "Lucky";

            player9.Play(player7);

            Console.WriteLine("-------------------");

            Player player10 = new SoreLoserUpperHalfPlayer();
            player10.Name = "Lucky Loser";

            player10.Play(player9);

            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, player4, player5, player6, player7, player8, player9, player10
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}