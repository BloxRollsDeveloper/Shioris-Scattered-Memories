using Ink.Runtime;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;
	private InputBehaviourSystem _inputSystem;


	[SerializeField] private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField] private GameObject dialogueBox = null;
	[SerializeField] private GameObject choicesBox = null;

	// UI Prefabs
	[SerializeField] private TextMeshProUGUI dialogueTextPrefab = null;
	[SerializeField] private TextMeshProUGUI speakerTextPrefab = null;
	[SerializeField] private Button buttonPrefab = null;

	
	// Assuming that the player will be speaking with one talent at a time, this one will be set to false,
	// until they are spoken to.
	public bool hasTalkedWith = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
    {
		_inputSystem = GetComponent<InputBehaviourSystem>();
	}

    // Update is called once per frame
    void Update()
    {
		if (_inputSystem.Interact && !hasTalkedWith)
		{
			// TODO: find a way to make the dialogue only continue when the player presses 'E'.
			StartStory();
		}
		
		if (story != null) 
		{
			if (_inputSystem.Interact && story.canContinue && hasTalkedWith)
			{
				ClearDialogueBox();
			
				print("Now, the story continues.");
			
				string text = story.Continue();
			
				text = text.Trim();
			
				dialogueTextPrefab.text = text;
				
				UponChoicesBorn();
			}
		}
    }

	public void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		
		hasTalkedWith = true;
		
		dialogueTextPrefab.text = "Press E to continue.";
		// RefreshDialogue();
	}

	public void RefreshDialogue()
	{
		ClearDialogueBox();
		
		if (story.currentChoices.Count > 0)
		{
			choicesBox.SetActive(true);

			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoices(choice.text.Trim());
				button.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
			}
		}
		/*else
		{
			Button choice = CreateChoices("End of story.\nRestart?");
			choice.onClick.AddListener(delegate { StartStory(); });
		}*/
	}

	private void UponChoicesBorn()
	{
		// this part of the code is called infinitely, because it checks if story is null every frame
		// TODO: figure out how to stop it from doing that
		if (!story.canContinue)
		{
			if (story.currentChoices.Count > 0)
			{
				choicesBox.SetActive(true);

				for (int i = 0; i < story.currentChoices.Count; i++)
				{
					Choice choice = story.currentChoices[i];
					Button button = CreateChoices(choice.text.Trim());
					button.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
				}
			}
		}
		else
		{
			print("Whoops, no choices here!");
		}
		
	}

	private void ClearDialogueBox()
	{
		dialogueTextPrefab.text = string.Empty;

		int childCount = choicesBox.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) 
		{
			Destroy(choicesBox.transform.GetChild(i).gameObject);
		}
	}

	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshDialogue();
	}

	Button CreateChoices(string text)
	{
		Button choice = Instantiate(buttonPrefab);
		choice.transform.SetParent(choicesBox.transform, false);

		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text = text;

		// Make sure the button fits the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}
}
