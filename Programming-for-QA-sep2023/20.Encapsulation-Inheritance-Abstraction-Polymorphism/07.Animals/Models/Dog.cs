﻿using System;

namespace Animals.Models;

internal class Dog : Animal
{
    public Dog(string name, string favoriteFood) : base(name, favoriteFood)
    {
    }

    public override string ExplainSelf()
    {
        return $"{base.ExplainSelf()}{Environment.NewLine}BORK";
    }
}
