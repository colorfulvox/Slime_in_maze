using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialoguemanager : MonoBehaviour
{
    public Text dialtext;

    private Queue<string> sentences;

    public GameObject textspace;

    public bool check=false;
    // Update is called once per frame
    private void Start()
    {
        sentences = new Queue<string>();
    }
   
    public void startdialogue(dialogue dial,Animator talk_motion) //대화 애니메이션 필요할 경우
    {
           check = true;
            textspace.SetActive(true);
            sentences.Clear();
            foreach (string sentence in dial.sentences)
            {
                sentences.Enqueue(sentence);
            }
           
            StopAllCoroutines();
            StartCoroutine(showtype(talk_motion));
   
    }
    public void startdialogue(dialogue dial) //dial의 모든 내용을 대화창만 필요한 경우
    {
        check =true;
        textspace.SetActive(true);
        sentences.Clear();
        foreach (string sentence in dial.sentences)
        {
            sentences.Enqueue(sentence);
        }
        StopAllCoroutines();
        StartCoroutine(showtype());

    }
    public void startdialogue(dialogue dial, Animator talk_motion,int index) //대화 애니메이션 필요할 경우
    {
        check = true;
        textspace.SetActive(true);
        sentences.Clear();

        string sentence = dial.sentences[index];
        Debug.Log(dial.sentences[index]);
        sentences.Enqueue(sentence);

        StopAllCoroutines();
        StartCoroutine(showtype(talk_motion));

    }
    public void startdialogue(dialogue dial,int index) //dial의 모든 내용을 대화창만 필요한 경우
    {
        check = true;
        textspace.SetActive(true);
        sentences.Clear();
        string sentence = dial.sentences[index];
        sentences.Enqueue(sentence);
        
        StopAllCoroutines();
        StartCoroutine(showtype());

    }

    IEnumerator showtype(Animator talk_motion)
    {
        while (sentences.Count != 0)
        {
            talk_motion.SetBool("talk", true);
            string sentence = sentences.Dequeue();
            dialtext.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialtext.text += letter;
                yield return new WaitForSeconds(0.08f);

            }
            talk_motion.SetBool("talk", false);
            yield return new WaitForSeconds(3f);
        }
        textspace.SetActive(false);
        check = false;
    }
    IEnumerator showtype()
    {
        while (sentences.Count != 0)
        {
            
            string sentence = sentences.Dequeue();
            dialtext.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialtext.text += letter;
                yield return new WaitForSeconds(0.08f);

            }
            yield return new WaitForSeconds(3f);
        }
        textspace.SetActive(false);
        check = false;
    }
}
