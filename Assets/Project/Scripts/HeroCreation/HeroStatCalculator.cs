using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroStatCalculator : MonoBehaviour
{
    [Header("Create and add Scriptable Objects")]
    public NameSO names;
    public ColorSO colorSO;
    public SizeSO sizeSO;
    public ShapeSO shapeSO;

    Hero hero;
    [HideInInspector] public List<Hero> heroes = new List<Hero>();    // we will hold hero info in a list

    //Creating Heroes
    private void Awake()
    {   
        
        for (int i = 0; i < names.nameList.Count; i++)
        {
            //Creating Random- Basic Heroes - we send name and take random feature for character 
            //name count that entered is our limitation
            hero = new Hero(names.nameList[i]);

            // than we set  heroes AP and HP stats according features
            SetHeroAP(hero);
            SetHeroHP(hero);
            heroes.Add(hero);                    
        }
    }

    // updating hero AP according to features of hero 
    void SetHeroAP(Hero hero)
    {

        // Check for Shape
        foreach (var item in shapeSO.shapeList)
        {
            if (hero.shapeType == item.shapeType)
            {
                hero.AP += item.AP;
                hero.sprite = item.sprite; // we assign sprite info to the hero that we create
            }
        }
        // Check for Size
        foreach (var item in sizeSO.sizeList)
        {
            if (hero.sizeType == item.sizeTypes)
            {
                hero.AP += item.AP;
            }
        }


        // Check for color
        foreach (var item in colorSO.colorList)
        {
            if (hero.colorType == item.colorType)
            {
                hero.material = item.material; // we assign material info to the hero that we create

                //under color we check again for the shape
                foreach (var shapeItem in item.shapeData)
                {
                    if (hero.shapeType==shapeItem.shapeType)
                    {
                        hero.AP += shapeItem.AP;
                    }
                }
            }
        }

    }

    // updating hero HP according to features of hero 
    void SetHeroHP(Hero hero)
    {
        // Check for Shape
        foreach (var item in shapeSO.shapeList)
        {
            if (hero.shapeType == item.shapeType)
            {
                hero.HP += item.HP;
            }
        }

        // Check for Size
        foreach (var item in sizeSO.sizeList)
        {
            if (hero.sizeType == item.sizeTypes)
            {
                hero.HP += item.HP;
            }
        }

        // Check for color
        foreach (var item in colorSO.colorList)
        {
            if (hero.colorType == item.colorType)
            {
                //under color we check again for the shape
                foreach (var shapeItem in item.shapeData)
                {
                    if (hero.shapeType == shapeItem.shapeType)
                    {
                        hero.HP += shapeItem.HP;
                    }
                }
            }
        }


    }
}
