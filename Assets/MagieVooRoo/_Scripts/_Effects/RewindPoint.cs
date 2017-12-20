using UnityEngine;

public class RewindPoint
{

    public Vector3 position;
    public Quaternion rotation;

    public RewindPoint(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }

}