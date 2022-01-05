// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;

static IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

static IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}

    var startingDeck = from s in Suits()
                       from r in Ranks()
                       select new { Suit = s, Rank = r };

    
    foreach (var card in startingDeck)
    {
        Console.WriteLine(card);
    }

    foreach (var c in startingDeck)
    {
        Console.WriteLine(c);
    }

    // 52 cards in a deck, so 52 / 2 = 26
    var top = startingDeck.Take(26);
    var bottom = startingDeck.Skip(26);
    var shuffle = top.InterleaveSequenceWith(bottom);
    foreach (var c in shuffle)
    {
        Console.WriteLine(c);
    }

    var times = 0;
    shuffle = startingDeck;
    do
    {
        shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));

        /*invierto SKip por Take, orden aleator
        io, intercale la baraja de tal forma que la primera carta 
        de la mitad inferior sea la primera carta de la baraja. Esto significa que la 
        última carta de la mitad superior será la carta inferior.*/

        foreach (var card in shuffle)
        {
            Console.WriteLine(card);
        }
        Console.WriteLine();
        times++;

    } while (!startingDeck.SequenceEquals(shuffle));

    Console.WriteLine(times);
