using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthlBar : MonoBehaviour
{
    public GameObject healthbar;

    
    /// <summary>
    /// Actualiza la barra de vida a partir del valor normalizado de la misma.
    /// </summary>
    /// <param name="normalizedValue">Valor de la vida normalizado entre 0 y 1</param>
    public void SetHP(float normalizedValue)
    {
        healthbar.transform.localScale = new Vector3(normalizedValue, 1.0f);
    }
}
