using UnityEditor;

public class ConfigsEditor : Editor
{
    private const string _settingsPath = "Assets/Configs/ConvertConfig.asset";

    [MenuItem("Convert/Config")]
    public static void OpenConfigs()
    {
        Selection.activeObject = ConfigInstance;
    }

    public static SaveConfigs ConfigInstance
    {
        get
        {
            var config = AssetDatabase.LoadAssetAtPath<SaveConfigs>(_settingsPath);
            if (config == null)
            {
                config = CreateInstance<SaveConfigs>();
                AssetDatabase.CreateAsset(config, _settingsPath);
            }

            return config;
        }
    }
}
