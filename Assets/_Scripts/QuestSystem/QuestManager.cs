using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private string quest0 = "Найти хозяина";
    private string quest1 = "Хозяин зажат и не может выбраться, в квартире напротив должен быть лом";
    private string quest2 = "Со стороны лестницы донеслись звуки разрушения. Надо посмотреть что случилось";
    private string quest3 = "Надо спуститься вниз, вдруг смогу найти бинты для человека";
    private string quest4 = "Скорее выйти с хозяином из квартиры!";

    public GameObject findHumanObject;
    public GameObject findLomObject;
    public GameObject searchForSoundsObject;
    public GameObject findMedicineObject;
    public GameObject leaveApartementsObject;

    public GameObject nextLevelEntrance;
    public GameObject nextLevelBeton;
    
    void Start()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest0;

        FindHuman.findHumanDone += findHumanDone;
        FindLom.findLomDone += findLomDone;
        SearchForSounds.searchForSoundsDone += searchForSoundsDone;
        FindMedicine.findMedicineDone += findMedicineDone;
        LeaveApartments.leaveApartmentsDone += leaveApartmentsDone;

        findHumanObject.SetActive(true);
        findLomObject.SetActive(false);
        searchForSoundsObject.SetActive(false);
        findMedicineObject.SetActive(false);
        leaveApartementsObject.SetActive(false);
    }

    void findHumanDone()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest1;

        findHumanObject.SetActive(false);
        findLomObject.SetActive(true);
    }

    void findLomDone()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest2;

        nextLevelEntrance.GetComponent<AudioSource>().Play();
        nextLevelBeton.SetActive(false);

        findLomObject.SetActive(false);
        searchForSoundsObject.SetActive(true);
    }

    void searchForSoundsDone()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest3;

        searchForSoundsObject.SetActive(false);
        findMedicineObject.SetActive(true);
    }

    void findMedicineDone()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest4;

        Human.AnimHuman.SetTrigger("LomReady");
        Human.canMove = true;
        Human.setFlipVariable();

        findMedicineObject.SetActive(false);
        leaveApartementsObject.SetActive(true);
    }

    void leaveApartmentsDone()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
