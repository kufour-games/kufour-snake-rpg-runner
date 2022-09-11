using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class ItemSlotsGameObject : MonoBehaviour
{
    [SerializeField] private List<ItemSlotGameObject> values;

    private int _slotIndex;

    private readonly ReadOnlyDictionary<KeyCode, int> _heroKeyCodeMapper = new(
        new Dictionary<KeyCode, int>(new[]
            {
                new KeyValuePair<KeyCode, int>(KeyCode.Alpha1, 1),
                new KeyValuePair<KeyCode, int>(KeyCode.Alpha2, 2),
                new KeyValuePair<KeyCode, int>(KeyCode.Alpha3, 3),
                new KeyValuePair<KeyCode, int>(KeyCode.Alpha4, 4),
                new KeyValuePair<KeyCode, int>(KeyCode.Alpha5, 5)
            }
        )
    );

    private void Start()
    {
        FocusInCurrentItemSlot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FocusOutCurrentItemSlot();
            SetNextFocus();
            FocusInCurrentItemSlot();
        }

        foreach (var keyCode in _heroKeyCodeMapper.Keys)
        {
            if (!Input.GetKeyDown(keyCode))
            {
                continue;                
            }

            object findHeroObject = _heroKeyCodeMapper[keyCode];
            Debug.Log(findHeroObject + " 영웅에게 " + _slotIndex + " 번 아이템을 적용");
            break;
        } 
    }

    private void SetNextFocus()
    {
        _slotIndex++;
        if (_slotIndex == values.Count)
        {
            _slotIndex = 0;
        }
    }

    private void FocusInCurrentItemSlot()
    {
        values[_slotIndex].FocusIn();
    }

    private void FocusOutCurrentItemSlot()
    {
        values[_slotIndex].FocusOut();
    }
}