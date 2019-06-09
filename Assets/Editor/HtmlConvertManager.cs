using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class HtmlConvertManager : MonoBehaviour
{
    private static MonoBehaviour[] _allItems;

    [MenuItem("Convert/Export to HTML5")]
    public static void ConvertToHtml()
    {
        CreateOutputDirectory();
        CopyThreeJs();

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

        using (StreamReader sr = new StreamReader(ConfigsEditor.ConfigInstance.TemplatePath))
        {
            data = sr.ReadToEnd();
        }

        data = data.Replace("[maincode]", toAdd);

        using (StreamWriter sw = new StreamWriter(Path.Combine(ConfigsEditor.ConfigInstance.SavePath, ConfigsEditor.ConfigInstance.HtmlName)))
        {
            sw.WriteLine(data);
        }
    }

    private static void CreateOutputDirectory()
    {
        if (!Directory.Exists(ConfigsEditor.ConfigInstance.SavePath))
        {
            Directory.CreateDirectory(ConfigsEditor.ConfigInstance.SavePath);
        }
    }

    private static void CopyThreeJs()
    {
        string jsPath = Path.Combine(ConfigsEditor.ConfigInstance.SavePath, "js");
        if (!Directory.Exists(jsPath))
        {
            string localJsPath = Path.Combine(ConfigsEditor.ConfigInstance.ThreePath);
            string destJsPath = Path.Combine(jsPath, "three.js");
            Directory.CreateDirectory(jsPath);
            File.Copy(localJsPath, destJsPath);
        }
    }
}
