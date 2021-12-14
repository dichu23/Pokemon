using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{ 
    
    private PokemonBase _base;
    private int _level;

    public Pokemon(PokemonBase pokemonBase,int pokemonLevel)
    {
        _base = pokemonBase;
        _level = pokemonLevel;
    }

    public int MaxHp => Mathf.FloorToInt((_base.MaxHp * _level) / 100.0f) + 10;
    public int Attack => Mathf.FloorToInt((_base.Attack * _level) / 100.0f) + 3;
    public int Defense => Mathf.FloorToInt((_base.Defense * _level) / 100.0f) + 3;
    public int SpAttack => Mathf.FloorToInt((_base.SpAttack * _level) / 100.0f) + 3;
    public int SpDefense => Mathf.FloorToInt((_base.SpDefense * _level) / 100.0f) + 3;
    public int Velocity => Mathf.FloorToInt((_base.Velocity * _level) / 100.0f) + 3;
    
    
    
}
