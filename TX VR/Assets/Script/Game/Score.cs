using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Score : MonoBehaviour
{
    static int score = 0;
    private string filePath = "scores.txt";
    private List<Tuple<int, string, int>> scores;

    void Awake()
    {
        this.scores = new List<Tuple<int, string, int>>();
    }

    void Start()
    {
        loadPreviousScores();
    }

    public static void increaseScore(int points)
    {
        if(points > 0)
        {
            Score.score += points;
            Debug.Log("New score : " + Score.score.ToString());
        }
    }

    public void loadPreviousScores()
    {
        string line;
        if (File.Exists(this.filePath))
        {
            StreamReader file = new StreamReader(this.filePath);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split('@');
                scores.Add(new Tuple<int, string, int>(Int32.Parse(words[0]), words[1], Int32.Parse(words[2])));
            }
            file.Close();
        }
        else
        {
            StreamWriter file = new StreamWriter(this.filePath);
            file.Close();
        }
    }

    public List<Tuple<int, string, int>> getBestScores(int limit)
    {
        List<Tuple<int, string, int>> retour = new List<Tuple<int, string, int>>();
        int temp = limit;
        foreach (Tuple<int, string, int> item in this.scores)
        {
            if (temp > 0)
            {
                retour.Add(item);
                temp--;
            }
        }
        return retour;
    }

    public void addScore(string teamName)
    {
        Debug.Log("Adding score : " + teamName + " = " + Score.score.ToString());
        bool flag = false;
        int count = 1;


        List<Tuple<int, string, int>> temp = new List<Tuple<int, string, int>>();
        foreach (Tuple<int, string, int> item in this.scores)
        {
            if ((item.Third <= Score.score) && !flag)
            {
                flag = true;
                temp.Add(new Tuple<int, string, int>(count, teamName, Score.score));
                count += 1;
                temp.Add(new Tuple<int, string, int>(count, item.Second, item.Third));
            }
            else
            {
                temp.Add(new Tuple<int, string, int>(count, item.Second, item.Third));
            }
            count += 1;
        }
        if (!flag)
        {
            temp.Add(new Tuple<int, string, int>(count, teamName, Score.score));
        }
        this.scores = temp;
        this.saveScores();
    }

    public void saveScores()
    {
        StreamWriter file = new StreamWriter(this.filePath, false);
        string line;
        foreach (Tuple<int, string, int> item in this.scores)
        {
            line = item.First.ToString() + "@" + item.Second + "@" + item.Third.ToString();
            file.WriteLine(line);
        }
        file.Close();
    }
}
