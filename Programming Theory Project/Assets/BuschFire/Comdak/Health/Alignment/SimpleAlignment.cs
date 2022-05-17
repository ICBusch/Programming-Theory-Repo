using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Alignment", menuName = "Space Comdak/Health/Alignment")]
public class SimpleAlignment : ScriptableObject, IAlignmentProvider
{
    public List<SimpleAlignment> FoeList = new List<SimpleAlignment>();

    public bool CanHarm(IAlignmentProvider other)
    {
        if (other == null)
            return true;
        var alignment = other as SimpleAlignment;
        return FoeList.Contains(alignment);
    }
}
