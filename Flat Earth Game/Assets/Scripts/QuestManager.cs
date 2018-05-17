using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	private string currentQuest; // The title of the current quest
	private List<string> objectives; // Names of objectives
	private List<bool> objectiveStatuses; // Status of objectives


	// Creates a new quest and sets objectives
	public void createNewQuest(string quest,List<string> objectives)
	{
		currentQuest = quest;
		this.objectives = objectives;
		this.objectiveStatuses = new List<bool> ();

		for(int i=0; i<objectives.Count; i++)
		{
			objectiveStatuses.Add (false);
		}
	}

	// Returns the percentage finished for the current quest
	public int getPercentageFinished()
	{
        if(this.objectiveStatuses == null)
        {
            return 0;
        }

		int finished =0;
		foreach( bool status in this.objectiveStatuses)
		{
			if (status == true)
			{
				finished++;
			}
		}
		return (int)((finished*100/ this.objectiveStatuses.Count)+1);
	}

	// Gets objectives title and new status to change the old status
	public void changeObjectiveStatus(string objective, bool status)
	{
		for(int i=0;i < this.objectiveStatuses.Count; i++)
		{
			if (this.objectives[i].Equals(objective))
			{
				this.objectiveStatuses[i] = status;
				break;
			}
		}
	}

	// Returns a list with the statuses of all the objectibes
	public List<bool> getObjectiveStatuses()
	{
		return this.objectiveStatuses;
	}

	// Returns list of objectives
	public List<string> getObjectives()
	{
		return this.objectives;
	}

	// Returns the title of the current quest
	public string getQuestTitle()
	{
		return this.currentQuest;
	}
	
}
