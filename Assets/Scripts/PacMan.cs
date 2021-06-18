using UnityEngine;

public class PacMan : MonoBehaviour
{
    [SerializeField] private float speed;
    private int xDir, yDir;

    public int XDir { get => xDir; set => xDir = value; }
    public int YDir { get => yDir; set => yDir = value; }

    private void Start()
    {
        xDir = 0;
        yDir = 0;
    }


    public void PacManUpdate()
    {
        Translate();
    }

    private void Translate()
    {
        var nx = transform.position.x + (xDir * speed);
        var ny = transform.position.y + (yDir * speed);

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, nx, Time.deltaTime), Mathf.Lerp(transform.position.y, ny, Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "Dots")
            {
            }
        }
    }
}