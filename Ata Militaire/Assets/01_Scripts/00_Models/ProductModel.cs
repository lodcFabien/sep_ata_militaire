using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "Product", menuName = "ScriptableObjects/Product", order = 1)]
public class ProductModel : ScriptableObject
{
    public string PopupName;
    public string Description;
    public GameObject ProductAsset;
}
