using UnityEngine;

public static class VectorExtensions 
{
    public static Vector3 ToThreePosition(this Vector3 vector)
    {
        var newPos = new Vector3(-vector.x, vector.y, vector.z);
        return newPos;
    }

    public static Vector3 ToThreeRoation(this Quaternion rotation)
    {
        Quaternion res = new Quaternion(-rotation.x, rotation.y, rotation.z, -rotation.w);
        var eulers = res.eulerAngles;
        var radiansVector = Mathf.Deg2Rad * new Vector3(eulers.x, 180+eulers.y, -eulers.z);
        return radiansVector;
    }
}
