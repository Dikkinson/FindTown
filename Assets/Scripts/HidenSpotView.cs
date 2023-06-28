using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemPosition { Under = -1, Front = 1 }

public class HidenSpotView : MonoBehaviour
{
    public ItemPosition itemPosition;
    public List<GameObject> hidenObjectsVariants;
}
