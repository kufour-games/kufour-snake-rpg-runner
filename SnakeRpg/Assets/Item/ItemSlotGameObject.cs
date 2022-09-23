
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotGameObject : MonoBehaviour
{
    [SerializeField] private Image image;
    private Color _focusOutColor;
    private readonly Color _focusInColor = new (76f/255f, 77f/255f, 16f/255f, 224f/255f);

    private void Start()
    {
        _focusOutColor = image.color;
    }
            
    public void FocusIn()
    {
        image.color = _focusInColor;
    }

    public void FocusOut()
    {
        image.color = _focusOutColor;
    }
}
