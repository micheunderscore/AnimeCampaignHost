using UnityEngine;
using System;

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
    public string id;
    public string name;
    public string epithet;
    public Stats stats;
    public string[] cClass;
    public Weapon weapon;
    public Talent[] talents;
    public Passive[] passives;
    public Ability[] abilities;
    public Outclass[] outclasses;
    public Character(string id, string name, Stats stats, string epithet = "UNKNOWN") {
        this.id = id;
        this.name = name;
        this.stats = stats;
        // TODO: Finish constructor for Character class
        this.cClass = new string[] { "..." };
        this.weapon = new Weapon();
        this.talents = new Talent[] { new Talent() };
        this.passives = new Passive[] { new Passive() };
        this.abilities = new Ability[] { new Ability() };
        this.outclasses = new Outclass[] { new Outclass() };
    }
}

[Serializable]
public class Stats {
    public int sta;
    public int mov;
    public int pro;
    public Stats(int sta, int mov, int pro) {
        this.sta = sta;
        this.mov = Mathf.Clamp(mov, 4, 6);
        this.pro = Mathf.Clamp(pro, 0, 100);
    }
}

[Serializable]
public class Weapon {
    public string name;
    public string desc;
    public Weapon(string name = "None", string desc = "...") {
        this.name = name;
        this.desc = desc;
    }
}

[Serializable]
public class Talent {
    public string name;
    public string desc;
    public int sta_penalty;
    public Talent(string name = "None", string desc = "...", int sta_penalty = 0) {
        this.name = name;
        this.desc = desc;
        this.sta_penalty = sta_penalty;
    }
}

[Serializable]
public class Passive {
    public string name;
    public string desc;
    public Passive(string name = "None", string desc = "...") {
        this.name = name;
        this.desc = desc;
    }
}

[Serializable]
public class Ability {
    public string name;
    public int cost;
    public bool spammable;
    public string desc;
    public Ability(string name = "None", int cost = 0, bool spammable = false, string desc = "...") {
        this.name = name;
        this.cost = cost;
        this.spammable = spammable;
        this.desc = desc;
    }
}

[Serializable]
public class Outclass {
    public string name;
    public string desc;
    public Outclass(string name = "None", string desc = "...") {
        this.name = name;
        this.desc = desc;
    }
}
