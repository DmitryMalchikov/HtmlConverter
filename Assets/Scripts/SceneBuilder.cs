using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SceneBuilder
{
    private MonoBehaviour[] _allItems;
    private StringBuilder _builder;

    public SceneBuilder(MonoBehaviour[] buildItems)
    {
        _allItems = buildItems;
        _builder = new StringBuilder();
    }

    public SceneBuilder CreateMaterials()
    {
        string res = string.Empty;
        IWithMaterial[] materials = _allItems.OfType<IWithMaterial>().ToArray();
        var groups = materials.GroupBy(m => m.MaterialName);
        foreach (var group in groups)
        {
            res += Environment.NewLine + group.First().ConvertMaterial();
        }

        _builder.AppendLine(res);
        return this;
    }

    public SceneBuilder CreateGeometries()
    {
        string res = string.Empty;
        IWithGeometry[] geometries = _allItems.OfType<IWithGeometry>().ToArray();
        var groups = geometries.GroupBy(m => m.GeometryName);
        foreach (var group in groups)
        {
            res += Environment.NewLine + group.First().ConvertGeometry();
        }

        _builder.AppendLine(res);
        return this;
    }
    public SceneBuilder CreateObjects()
{
    string res = string.Empty;
    IHtmlConvertable[] items = _allItems.OfType<IHtmlConvertable>().ToArray();

    foreach (var item in items)
    {
        res += Environment.NewLine + item.ConvertToHtml();
    }
    _builder.AppendLine(res);
    return this;
}

public SceneBuilder CreateSceneAndRenderer()
{
    var res = "var scene = new THREE.Scene();" +
    "\nvar renderer = new THREE.WebGLRenderer();" +
    "\nrenderer.setSize(window.innerWidth, window.innerHeight);" +
    "\ndocument.body.appendChild(renderer.domElement); ";
    _builder.AppendLine(res);
    return this;
}

public SceneBuilder Render(string cameraName)
{
    var res = $"renderer.render( scene, {cameraName} );";
    _builder.AppendLine(res);
    return this;
}

public string Build()
{
    return _builder.ToString();
}
}
