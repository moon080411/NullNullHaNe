using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementLevel : MonoBehaviour
{
    public Dictionary<ElementType , int> ElementLevel = new Dictionary<ElementType , int>();
    private void Awake()
    {
        ElementLevel.Add(ElementType.Normal, 1);
        ElementLevel.Add(ElementType.Fire, 1);
        ElementLevel.Add(ElementType.Water, 1);
        ElementLevel.Add(ElementType.Wind, 1);
        ElementLevel.Add(ElementType.Lightning, 1);
    }
}