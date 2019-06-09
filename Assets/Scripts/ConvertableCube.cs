public class ConvertableCube : ThreeObject, IHtmlConvertable, IWithMaterial, IWithGeometry
{
    public string MaterialName => "whiteMaterial";
    public string GeometryName => "cubeGeometry";

    public string ConvertGeometry()
    {
        return $"var {GeometryName} = new THREE.BoxGeometry{transform.localScale.ToString("G4")};";
    }

    public string ConvertMaterial()
    {
        return $"	var {MaterialName} = new THREE.MeshBasicMaterial( {{ color: 0xffffff }} );";
    }

    public string ConvertToHtml()
    {
        string res = $"var {Name} = new THREE.Mesh( {GeometryName}, {MaterialName} );" +
          ConvertTransform() +
          $"\nscene.add({Name}); ";

        return res;
    }
}
