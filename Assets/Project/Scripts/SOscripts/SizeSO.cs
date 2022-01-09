using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Sizes", menuName = "Sizes")]
public class SizeSO : ScriptableObject
{
    public List<SizeData> sizeList = new List<SizeData>();    
}


[System.Serializable]
public class SizeData
{
    public SizeTypes sizeTypes;
    public int HP;
    public int AP;
}