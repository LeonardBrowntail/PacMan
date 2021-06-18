using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool running = true;

    //Reference Holders
    private PacMan player;

    private Dot dot;
    private Ghost[] ghosts = new Ghost[4];

    //Spawnpoints
    [SerializeField] private Transform pacSpawn;

    [SerializeField] private Transform tilemapParent;
    [SerializeField] private Transform ghostSpawn;

    //Factories
    public PacManFactory pacFac;

    public DotFactory dotFac;
    public GhostFactory ghoFac;

    //Create instances
    private void Start()
    {
        //Create instance for PacMan
        player = pacFac.GetInstance(pacSpawn.transform.position, null);

        //Create instance for dots
        dot = dotFac.GetInstance(tilemapParent.transform.position, tilemapParent);
        dot.Init();

        //Create instances for ghosts
        for (int i = 0; i < 4; i++)
        {
            ghosts[i] = ghoFac.GetInstance(ghostSpawn.transform.GetChild(i).transform.position, ghostSpawn);
            ghosts[i].Id = i;
        }
    }

    //Code run loop
    private void Update()
    {
        if (running)
        {
            DetectKeyPress();
            player.PacManUpdate();
        }
    }

    //Detect player input
    private void DetectKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.YDir = 1;
            player.XDir = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.YDir = 0;
            player.XDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.YDir = 0;
            player.XDir = -1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.YDir = -1;
            player.XDir = 0;
        }
    }
}