using UnityEngine;

[CreateAssetMenu]
public class CharacterInitData : ScriptableObject
{
    [SerializeField] private GameObject playerGOPrefab;
    [SerializeField] private float moveSpeed;

    public GameObject PlayerGOPrefab { get => playerGOPrefab; }
    public float MoveSpeed { get => moveSpeed; }
}
