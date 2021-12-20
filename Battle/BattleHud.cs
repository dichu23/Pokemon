using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
 public Text pokemonName;
 public Text pokemonLevel;
 public HealthlBar healthbar;
 public Text pokemonHeatlh;

 public void SetPokemonData(Pokemon pokemon)
 {
  pokemonName.text = pokemon.Base.Name;
  pokemonLevel.text = $"Lvl {pokemon.Level}";
  healthbar.SetHP(pokemon.Hp/pokemon.MaxHp);
  pokemonHeatlh.text = $"{pokemon.Hp}/{pokemon.MaxHp}";
 }
}
