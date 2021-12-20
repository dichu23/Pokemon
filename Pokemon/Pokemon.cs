using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{ 
    
    private PokemonBase _base;

    public PokemonBase Base => _base;


    private int _level;

    public int Level
    {
        get => _level;
        set => _level = value;
    }


    private List<Move> _moves;
    
    public List<Move> Moves
    {
        get => _moves;
        set => _moves = value;
    }
//vida actual de pokemon
    private int _hp;
//vida maxima del pokemon
    public int Hp
    {
        get => _hp;
        set => _hp = value;
    }

    public Pokemon(PokemonBase pokemonBase,int pokemonLevel)
    {
        _base = pokemonBase;
        _level = pokemonLevel;

        _hp = MaxHp;
        
        _moves = new List<Move>();

        foreach (var Lmove in _base.LearnableMoves)
        {
            if (Lmove.Level <= _level)
            {
                _moves.Add(new Move(Lmove.Move));
            }

            if (_moves.Count >= 4)
            {
                break;
            }
        }
        
        
    }

    public int MaxHp => Mathf.FloorToInt((_base.MaxHp * _level) / 20.0f) + 10;
    public int Attack => Mathf.FloorToInt((_base.Attack * _level) / 100.0f) + 3;
    public int Defense => Mathf.FloorToInt((_base.Defense * _level) / 100.0f) + 3;
    public int SpAttack => Mathf.FloorToInt((_base.SpAttack * _level) / 100.0f) + 3;
    public int SpDefense => Mathf.FloorToInt((_base.SpDefense * _level) / 100.0f) + 3;
    public int Velocity => Mathf.FloorToInt((_base.Velocity * _level) / 100.0f) + 3;
    
    
    
}
