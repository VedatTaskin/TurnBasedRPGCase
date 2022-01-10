using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero :MonoBehaviour
{   

    [HideInInspector] public string Name { get; set; }
    [HideInInspector] public int HP { get; set; } = 100; // default values
    [HideInInspector] public int AP { get; set; } = 10; // default values
    [HideInInspector] public ShapeTypes shapeType { get;}
    [HideInInspector] public SizeTypes sizeType { get;}
    [HideInInspector] public ColorTypes colorType { get;}
    [HideInInspector] public Material material { get; set; }
    [HideInInspector] public Sprite sprite { get; set; }



    //Constructor
    public Hero(string name)
    {
        Name = name;
        colorType = Utility.RandomEnumValue<ColorTypes>();
        shapeType = Utility.RandomEnumValue<ShapeTypes>();
        sizeType = Utility.RandomEnumValue<SizeTypes>();        
    }



}
