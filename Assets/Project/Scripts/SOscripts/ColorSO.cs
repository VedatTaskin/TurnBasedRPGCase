using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Colors", menuName = "Colors")]
public class ColorSO : ScriptableObject
{
    public List<ColorData> colorList = new List<ColorData>();
}


[System.Serializable]
public class ColorData
{
    public ColorTypes colorType;
    public Material material;
    public ShapeData [] shapeData; // we need this for assigning different values according to shape

}