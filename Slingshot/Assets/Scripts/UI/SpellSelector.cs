using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject boomerang;
    [SerializeField] private GameObject redirect;
    public static GameObject SelectedSpellPrefab { get; private set; }

    public void OnFireballClicked() {
        SelectedSpellPrefab = fireball;
        Debug.Log("Spell selected: Fireball");
    }

    public void OnRedirectClicked() {
        SelectedSpellPrefab = boomerang;
        Debug.Log("Spell selected: Boomerang");
    }

    public void OnBoomerangClicked() {
        SelectedSpellPrefab = redirect;
        Debug.Log("Spell selected: Redirect");
    }
}
