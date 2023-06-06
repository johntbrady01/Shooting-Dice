using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {

        public List<string> Taunts = new List<string> {
            "Ever rolled a dice before? It doesnt seem like it", "Scared yet?", "I wouldnt want to face me neither", "My two year old neice is better than you"
        };


        public override void Play(Player other)
        {
            var rnd = new Random();
            int TauntIndex = rnd.Next(Taunts.Count);
            string Taunt = Taunts[TauntIndex];

            // Call roll for "this" object and for the "other" object
            int myRoll = Roll();
            int otherRoll = other.Roll();

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{Taunt}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }

    }
}