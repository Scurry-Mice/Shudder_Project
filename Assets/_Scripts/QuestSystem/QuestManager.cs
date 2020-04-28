using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private string quest0 = "Найти хозяина";
    private string quest1 = "Хозяин прижат и не может выбраться, думает о каком то ломе, что это?";
    private string quest2 = "Со стороны лестницы донеслись звуки ращрушения. Надо пойти и посмотреть";
    private string quest3 = "Хм, в таком состоянии он далеко не уйдет, надо найти бинты";
    private string quest4 = "Скорее выйти с хозяином из квартиры!";

    public GameObject findHumanObject;
    public GameObject findLomObject;
    public GameObject findMedicineObject;
    public GameObject leaveApartementsObject;

    public GameObject nextLevelEntrance;
    public GameObject nextLevelBeton;
    
    void Start()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest0;

        FindHuman.findHumanDone += findHumanDone;
        FindLom.findLomDone += findLomDone;
        FindMedicine.findMedicineDone += findMedicineDone;
        LeaveApartments.leaveApartmentsDone += leaveApartmentsDone;

        findHumanObject.SetActive(true);
        findLomObject.SetActive(false);
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
        findMedicineObject.SetActive(true);
    }

    void findSounds()
    {

    }

    void findMedicineDone()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest3;

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
