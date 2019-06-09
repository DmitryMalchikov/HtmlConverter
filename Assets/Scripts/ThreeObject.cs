using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ThreeObject : MonoBehaviour
{
    public string Position
    {
        get
        {
            return transform.position.ToThreePosition().ToString("G4");
        }
    }

    public string Rotaion
    {
        get
        {
            return transform.rotation.ToThreeRoation().ToString("G4");
        }
    }

    public string Scale
    {
        get
        {
            return transform.localScale.ToString("G4");
        }
    }

    public string Name => Regex.Replace(gameObject.name, "[^a-zA-Z0-9]", "");
}
