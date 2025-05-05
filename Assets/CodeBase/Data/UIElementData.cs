using System;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[Serializable]
public class UIElementData
{
    public UIElementId Id;
    public Vector2 Position;
    public Vector2 Scale;
    public float Alpha;

    public UIElementData(UIElementId id)
    {
        Id = id;
    }

    public UIElementData(UIElementData staticData)
    {
        Id = staticData.Id;
        Position = staticData.Position;
        Scale = staticData.Scale;
        Alpha = staticData.Alpha;
    }

    public void SetData(Vector2 position, Vector3 scale, float alpha)
    {
        Position = position;
        Scale = scale;
        Alpha = alpha;
    }
}
