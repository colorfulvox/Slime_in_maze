using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class receptionist_inter : MonoBehaviour
{

    Animator receptionist_ani;
    public GameObject receptionist;

    public dialogue tutorial_dial;
    public dialogue dial;

     bool tutorial_check = false; //나중에 구글 연동하여 바꿀 것  바꾸면 튜툐 or 일반
     bool tutorial_talk= false;

    public GameObject click;
    int random_inter;


    int dial_index = -1;
    int dial_control = 0;
    private void Start()
    {
        if (tutorial_check == false) FindObjectOfType<dialoguemanager>().check = true;  //튜툐가 없을 경우 자동 true

        receptionist_ani = transform.GetComponent<Animator>();
        if(tutorial_check)receptionist.GetComponent<Button>().enabled = true;
     
    }

    void Update() 
    {
        if (tutorial_check == false)
        {
            if (tutorial_talk == false)
            {
                tutorial_talk= true;
                Invoke("receipt_tutorial", 3f);
            }
            else if (!FindObjectOfType<dialoguemanager>().check)
            {
                receptionist_ani.SetBool("click", true);
                click.SetActive(true);
                receptionist.GetComponent<Button>().enabled = true;
            }
        }
      else  if (tutorial_check == true)
        {

            if (!(receptionist_ani.GetBool("blink") && receptionist_ani.GetBool("talk"))) Invoke("random_inter_control", 1f);
            if (random_inter == 5 && !receptionist_ani.GetBool("blink"))
            {
                receptionist_ani.SetBool("blink", true);
            }
            else if (random_inter == 10 && !FindObjectOfType<dialoguemanager>().check)
            {  
                dial_index = Random.Range(0, dial.sentences.Length);
                if(dial_index == dial_control) while(dial_index == dial_control)dial_index = Random.Range(0, dial.sentences.Length);
                FindObjectOfType<dialoguemanager>().startdialogue(dial, receptionist_ani,dial_index);
                dial_control = dial_index;
            }
                random_inter = 0;
        }
        
    }



    public void stopblink()
    {
        transform.GetComponent<Animator>().SetBool("blink", false);
    }

    void receipt_tutorial()
    {
        FindObjectOfType<dialoguemanager>().startdialogue(tutorial_dial, receptionist_ani);
    }

   public void move_questreceipt()
    {
        SceneManager.LoadScene("questreceipt");
    }
    public void random_inter_control()
    {
        random_inter = Random.Range(0, 1000);
    }

  }
