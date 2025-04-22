using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCountDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text spellCountText;

    void Update()
    {
        spellCountText.text = $"Spells: {LevelController.spellCount}";
    }
}
