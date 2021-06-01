using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedToDelete : MonoBehaviour
{
    [ContextMenu("GoGoGo")]
    public void SuperMethod()
    {
        var rectTransform = this.transform as RectTransform;
    }
}