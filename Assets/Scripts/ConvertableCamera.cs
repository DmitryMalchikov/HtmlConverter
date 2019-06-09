using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ConvertableCamera : ThreeObject, IHtmlConvertable
{
    [SerializeField] private Camera _camera;

    public string ConvertToHtml()
    {
        return $"	var {Name} = new THREE.PerspectiveCamera( {_camera.fieldOfView}, window.innerWidth/window.innerHeight,{_camera.nearClipPlane}, {_camera.farClipPlane} );" +
         ConvertTransform();
    }

    private void OnValidate()
    {
        _camera = GetComponent<Camera>();
    }
}
