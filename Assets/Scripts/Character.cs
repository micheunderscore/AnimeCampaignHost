using System;
using System.Reflection;

[Serializable]
public class GameData {
    public Piece[] pieces;
}

[Serializable]
public class Piece {
    public string name;
    public Character[] characters;
}

[Serializable]
public class Character {
    public string name;
    public string epithet;
    public Stats stats;
    public string[] cClass;
    public Weapon weapon;
    public Talent[] talents;
    public Passive[] passives;
    public Ability[] abilities;
    public Outclass[] outclasses;
}

[Serializable]
public class Stats {
    public int sta;
    public int mov;
    public int pro;
}

[Serializable]
public class Weapon {
    public string name;
    public string desc;
}

[Serializable]
public class Talent {
    public string name;
    public string desc;
    public int sta_penalty;
}

[Serializable]
public class Passive {
    public string name;
    public string desc;
}

[Serializable]
public class Ability {
    public string name;
    public int cost;
    public bool spammable;
    public string desc;
}

[Serializable]
public class Outclass {
    public string name;
    public string desc;
}
