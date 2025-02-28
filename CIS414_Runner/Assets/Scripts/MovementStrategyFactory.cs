//Michael A 2/6/25
//John Burke's Lecture

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementStrategyFactory
{
    public static IMovementStrategy GetStrategy(string aPowerUpTag)
    {
        IMovementStrategy strategy = null;

        switch (aPowerUpTag)
        {
            case "RedStrategy":
                strategy = new RedStrategy();
                break;
            case "YellowStrategy":
                strategy = new YellowStrategy();
                break;
            case "GreenStrategy":
                strategy = new GreenStrategy();
                break;
            case "PurpleStrategy":
                strategy = new PurpleStrategy();
                break;
            default:
                strategy = new YellowStrategy();
                break;
        }
        return strategy;
    }
}
