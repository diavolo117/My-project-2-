using UnityEngine;
using UnityEngine.SceneManagement;

public class lives : MonoBehaviour
{
    [SerializeField] public float health;
    public float currhealth { get; private set; }
    string currentSceneName;
    private void Awake()
      
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        currhealth = health;
    }
    public void facebreak(float _damage)
    {
        currhealth = Mathf.Clamp(currhealth - _damage, 0, health);
        if (currhealth > 0) 
        {
            GetComponent<damage>().respawn();

        }
        else
        {
            SceneManager.LoadScene(currentSceneName);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("lvl2");
            print(1);
        }
    }
}
