using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    [Header("Spell Prefabs")]
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject boomerang;
    [SerializeField] private GameObject redirect;

    [Header("Spawn Point")]
    [SerializeField] private Transform spawnPoint; 
      // assign an empty GameObject in the scene at your desired launch origin

    private Spell currentSpell;

    void Start()
    {
        // spawn the default spell once at Start
        currentSpell = SpawnSpell(fireball);
    }

    public void OnFireballClicked()    => SwapSpell(fireball,   "Fireball");
    public void OnBoomerangClicked()  => SwapSpell(boomerang, "Boomerang");
    public void OnRedirectClicked()   => SwapSpell(redirect,  "Redirect");

    private void SwapSpell(GameObject prefab, string name)
    {
        // 1) destroy the old one if it still exists
        if (currentSpell != null)
            Destroy(currentSpell.gameObject);

        // 2) spawn the new one at spawnPoint
        currentSpell = SpawnSpell(prefab);
    }

    private Spell SpawnSpell(GameObject prefab)
    {
        var go = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        return go.GetComponent<Spell>();
    }
}
