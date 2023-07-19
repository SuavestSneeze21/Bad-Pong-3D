using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;

        bool pauseEnabled;

        private void Start()
        {
            if (pauseMenu)
                pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel") && !pauseEnabled)
            {
                if (pauseMenu)
                {
                    Time.timeScale = 0;

                    pauseMenu.SetActive(true);
                    pauseEnabled = true;
                }
            }
            else if (Input.GetButtonDown("Cancel") && pauseEnabled)
            {
                if (pauseMenu)
                {
                    Time.timeScale = 1;

                    pauseMenu.SetActive(false);
                    pauseEnabled = false;
                }
            }
        }
        public void LoadScene(int scene)
        {
            Time.timeScale = 1;

            SceneManager.LoadSceneAsync(scene);
        }

        public void Quit()
        {
            Time.timeScale = 1;

            Application.Quit();
        }
    }
}
