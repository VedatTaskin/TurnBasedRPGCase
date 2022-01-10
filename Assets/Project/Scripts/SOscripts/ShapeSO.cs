using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Shapes", menuName = "Shapes")]
public class ShapeSO : ScriptableObject
{
    public List<ShapeData> shapeList = new List<ShapeData>();
}


[System.Serializable]
public class ShapeData
{
    public ShapeTypes shapeType;
    public int HP;
    public int AP;
    public Sprite sprite;
}


