using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ThreeObject : MonoBehaviour
{
    public string ConvertTransform()
    {
        return $"\n{Name}.position.set{Position};" +
                    $"\n{Name}.rotation.set{Rotaion};" +
                    $"\n{Name}.scale.set{Scale};";
    }

    public string Position
    {
        get
        {
            return transform.position.ToThreePosition().ToString("G6");
        }
    }

    public string Rotaion
    {
        get
        {
            return transform.rotation.ToThreeRoation().ToString("G6");
        }
    }

    public string Scale
    {
        get
        {
            return transform.localScale.ToString("G6");
        }
    }

    public string Name => Regex.Replace(gameObject.name, "[^a-zA-Z0-9]", "");
}
