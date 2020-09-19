using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool wearingNightgown = true;
    // public int health = 10;
    // public int wheat = 0;

    InventoryItem[] inventory = new InventoryItem[0];

    Vector2 nextPosition;
    Vector3 nextCameraPosition;
    Vector2 nextDirection;

    protected GameManager() { }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(string scene, Vector2 toPosition, Vector3 toCameraPosition, Vector2 toDirection)
    {
        nextPosition = toPosition;
        nextCameraPosition = toCameraPosition;
        nextDirection = toDirection;

        SceneManager.LoadScene(scene);
    }

    public void DebugInventory()
    {
        foreach (InventoryItem i in inventory)
        {
            Debug.Log(i.name);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.Find("Player").gameObject;
        player.transform.position = nextPosition;
        Animator animator = player.transform.GetComponent<Animator>();
        animator.SetFloat("moveX", nextDirection.x);
        animator.SetFloat("moveY", nextDirection.y);

        Camera.main.transform.position = nextCameraPosition;
    }
}
