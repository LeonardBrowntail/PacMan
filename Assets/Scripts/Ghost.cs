using UnityEngine;

public class Ghost : MonoBehaviour
{
    protected int id;
    public int Id { get => id; set => id = value; }
    [SerializeField] private Sprite[] sprites = new Sprite[4];

    public void Init()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[id];
    }
}