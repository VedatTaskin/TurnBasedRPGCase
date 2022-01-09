using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Names", menuName = "Names")]
public class NameSO : ScriptableObject
{
   public List<string> nameList = new List<string>();

}
