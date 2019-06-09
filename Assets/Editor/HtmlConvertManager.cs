using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class HtmlConvertManager : MonoBehaviour
{
    public const string SavePath = @"D:\HtmlConverter";
    private static MonoBehaviour[] _allItems;

    [MenuItem("Html/Convert Scene to Html")]
    public static void ConvertToHtml()
    {
        System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        _allItems = FindObjectsOfType<ThreeObject>();
        var builder = new SceneBuilder(_allItems);
        string cameraName = _allItems.OfType<ConvertableCamera>().First().Name;

        string data = string.Empty;
        string toAdd = builder.CreateSceneAndRenderer()
            .CreateMaterials()
            .CreateGeometries()
            .CreateObjects()
            .Render(cameraName)
            .Build();

        using (StreamReader sr = new StreamReader(Path.Combine(Application.streamingAssetsPath, "HtmlTemplate.html")))
        {
            data = sr.ReadToEnd();
        }

        data = data.Replace("[maincode]", toAdd);

        using (StreamWriter sw = new StreamWriter(Path.Combine(SavePath, "Test.html")))
        {
            sw.WriteLine(data);
        }
    }
}
