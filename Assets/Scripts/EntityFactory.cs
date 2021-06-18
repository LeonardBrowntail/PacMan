using UnityEngine;

public class EntityFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T prefab;

    public T GetInstance(Vector3 spawn, Transform prnt)
    {
        return Instantiate(prefab, spawn, prefab.transform.rotation, prnt);
    }
}