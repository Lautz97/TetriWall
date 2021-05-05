using UnityEngine;

public class PawnBehaviour : Singleton<PawnBehaviour>
{
    [SerializeField] private Material BGMaterial;
    [SerializeField] private float parallaxFactor = 1;
    public float speed = 15;
    public float speedMultiplier = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        BGMaterial.mainTextureOffset = Vector2.zero;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        BGMaterial.mainTextureOffset += (Vector2.up * speed * speedMultiplier * Time.deltaTime) / parallaxFactor;
        transform.position += (Vector3.forward * Time.deltaTime * speed * speedMultiplier);
    }
    private void OnEnable()
    {
        StateManager.OnPlay += AddBooster;
    }

    private void OnDisable()
    {
        StateManager.OnPlay -= AddBooster;
    }

    void AddBooster()
    {
        if (!StateManager.isInitialized)
            gameObject.AddComponent<InitialPawnBooster>();
    }
}
