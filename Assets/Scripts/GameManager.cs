using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer MoneyFarmingTimer;
    public ImageTimer PayDayTimer;
    public Image RaidTimer;
    public Image WorkerTimerImg;
    public Image PoliceTimerImg;
    public AudioSource WorkerSound;
    public AudioSource PoliceSound;


    public Button workerButton;
    public Button policeButton;

    public Text resourceText;

    public int workerCount;
    public int policeCount;
    public int moneyCount;

    public int moneyperWorker;
    public int moneytoPolice;

    public int workerCost;
    public int policeCost;

    public float workerCreateTime;
    public float policeCreateTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;
    public GameObject WinScreen;
    public GameObject GameOverScreen;
    private float workerTimer = -2;
    private float policeTimer = -2;
    private float raidTimer;
    private bool musicoff;
    public AudioSource BackGroundMusic;




    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;

    }

    void Update()
    {
        raidTimer -= Time.deltaTime;
        RaidTimer.fillAmount = raidTimer / raidMaxTime;
        if(raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            policeCount -= nextRaid;
            nextRaid += raidIncrease;
        }
        if (MoneyFarmingTimer.Tick)
        {
            moneyCount += workerCount * moneyperWorker; 
        }
        if (PayDayTimer.Tick)
        {
            moneyCount -= policeCount * moneytoPolice;
        }
        if (workerTimer > 0)
        {
            workerTimer -= Time.deltaTime;
            WorkerTimerImg.fillAmount = workerTimer / workerCreateTime;
        }
        else if (workerTimer > -1)
        {
            WorkerTimerImg.fillAmount = 0;
            workerButton.interactable = true;
            workerCount += 1;
            workerTimer = -2;
            WorkerSound.Play();
        }
        if (policeTimer > 0)
        {
            policeTimer -= Time.deltaTime;
            PoliceTimerImg.fillAmount = policeTimer / policeCreateTime;
        }
        else if (policeTimer > -1)
        {
            PoliceTimerImg.fillAmount = 0;
            policeButton.interactable = true;
            policeCount += 1;
            policeTimer = -2;
            PoliceSound.Play();
        }

        UpdateText();
        if (policeCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
        if (moneyCount == 200)
        {
            Time.timeScale = 0;
            WinScreen.SetActive(true);
        }
    }
    public void CreateWoker()
    {
        if(moneyCount < workerCost)
        {
            workerButton.interactable = true;
        }
        else
        {
            moneyCount -= workerCost;
            workerTimer = workerCreateTime;
            workerButton.interactable = false;
        }

    }
    public void CreatePolice()
    {
        if (moneyCount < policeCost)
        {
            policeButton.interactable = true;
        }
        else
        {
            moneyCount -= policeCost;
            policeTimer = policeCreateTime;
            policeButton.interactable = false;

        }
    }
    private void UpdateText()
    {
        resourceText.text = workerCount + "\n" + policeCount + "\n\n" + moneyCount;
    }

    public void TurnMusic()
    {
        if (musicoff)
        {
            BackGroundMusic.Play();
        }
        else
        {
            BackGroundMusic.Pause();
        }
        musicoff = !musicoff;
    }

}
