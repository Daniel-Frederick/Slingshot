using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    [Header("Spell Prefabs")]
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject boomerang;
    [SerializeField] private GameObject redirect;

    [Header("Spawn Point")]
    [SerializeField] private Transform spawnPoint; 

    private Spell currentSpell;

    void Start()
    {
        currentSpell = SpawnSpell(fireball);
    }

    public void OnFireballClicked() => SwapSpell(fireball, "Fireball");
    public void OnBoomerangClicked() => SwapSpell(boomerang, "Boomerang");
    public void OnRedirectClicked() => SwapSpell(redirect, "Redirect");

    private void SwapSpell(GameObject prefab, string name)
    {
        if (currentSpell != null && !currentSpell.IsLaunched) {
            Destroy(currentSpell.gameObject);
            currentSpell = SpawnSpell(prefab);
        }
    }

    public Spell SpawnSpell(GameObject prefab)
    {
        var go = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        var spell = go.GetComponent<Spell>();
        spell.Initialize(this, prefab);
        currentSpell = spell;
        return spell;
    }

}
