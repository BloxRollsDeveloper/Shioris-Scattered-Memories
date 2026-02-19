using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VNHandler : MonoBehaviour
{
    // left and right characters Sprite components
    public SpriteRenderer leftSceneCharacter;
    public SpriteRenderer rightSceneCharacter;

    //Text boxes
    public Text currentSpeakerName;
    public Text currentText;

    public string nextTriviaSceneName;
    //which VN event to show
    //it counts up every time NextVNScene() is called
    int sceneVNEventIndex = -1;

    //Audio
    AudioSource vnAudioSource;

    /// <summary>
    /// late patchwork
    /// </summary>
    VNEvent currentEvent;
    //serializable class for VN Events. 
    //A VN event is: 
    //One, Two, or Zero characters. 
    //Leave "current...Paperdoll" blank if you want left or right side blank. 
    //better VN systems have more spots for characters, art, etc. This will suffice. 
    [System.Serializable]
    public class VNEvent
    {
        //graphics for current speakers, leave blank for none
        //the pictures
        public Sprite currentLeftSprite;
        public Sprite currentRightSprite;


        //the nameplate text
        public string currentSpeakerName; //can be blank
        //the words 
        public string currentText;
        
        //the voice clip . It plays once
        //I won't do auto yet, requires timing with voice clips and just nope 
        public AudioClip currentVAClip; //can be blank 
    }

    //where you fill it all in
    public VNEvent[] eventsForThisLevel;
    
    void Start()
    {
        //Audio init
        vnAudioSource = this.GetComponent<AudioSource>();

        //immediately go to scene 0 in array
        NextVNScene();
    }


    //Go to next event, do next event
    public void NextVNScene()
    {
        //if before the end of the VN 
        if (sceneVNEventIndex < eventsForThisLevel.Length-1)
        {
            //advance the next VN scene
            sceneVNEventIndex += 1;

            //cleaner code to reference the events data
            currentEvent = eventsForThisLevel[sceneVNEventIndex];
        }
        else
        {
            // go to trivia  when VN is over
            // PersistentGameState gameState = FindAnyObjectByType<PersistentGameState>();
            // gameState.ChangeScene(nextTriviaSceneName);
            SceneManager.LoadScene(nextTriviaSceneName);
        }


        //replace the text with the text from eventsForThisLevel[]
        currentSpeakerName.text = currentEvent.currentSpeakerName;
        currentText.text = currentEvent.currentText;

        //same with graphics
        leftSceneCharacter.sprite = currentEvent.currentLeftSprite;
        rightSceneCharacter.sprite = currentEvent.currentRightSprite;

        //now play the sound clip 
        //tell the audio source to load clip
        vnAudioSource.clip = currentEvent.currentVAClip;
        //then plays
        vnAudioSource.Play();

    }
}
