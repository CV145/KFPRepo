using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int Level;
    public string SceneName = "Level1";
    public Sprite UnlockedImage;
    public Sprite LockedImage;
    public bool IsBackArrow;
    Button B;
    private void Start()
    {
        B = GetComponent<Button>();
        if (IsBackArrow)
        {
            B.onClick.AddListener(ReturnToMenu);
            return;
        }

        if (LevelSystem.UnlockedLevels.Contains(Level))
        {
            //level exists
            B.gameObject.AddComponent<Logo>();
            B.GetComponent<Image>().sprite = UnlockedImage;
            B.onClick.AddListener(LoadLevel);
        } else
        {
            //level does not exist;
            B.onClick.AddListener(ButtonFail);
            B.GetComponent<Image>().sprite = LockedImage;
        }
    }

    private void Update()
    {
        if (transform.rotation != Quaternion.identity)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity,0.1f);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonFail()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(-4, 4.1f)));
        B.GetComponent<Image>().color = Color.red;
        StartCoroutine(RedReturn());
    }

    IEnumerator RedReturn()
    {
        yield return new WaitForEndOfFrame();
        Image I = B.GetComponent<Image>();
        if (I.color != Color.white)
        {
            I.color = Color.Lerp(I.color, Color.white, 0.05f);
            StartCoroutine(RedReturn());
        }
    }

    public void LoadLevel()
    {
        LevelSystem.LevelDifficulty = Level;
        SceneManager.LoadScene(SceneName);
    }
}
