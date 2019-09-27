using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRandomizer : MonoBehaviour
{
    public static StringRandomizer Instance;

    string result;
    public int characterCount;
    int count;
    int[] nums = {0,1,2,3,4,5,6,7,8,9 };
    string[] lettersCapital = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y"};
    string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y"};
    [HideInInspector]
    public List<string> results;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    void GetRandomResult()
    {
        results.Clear();
        int letterChooseIndex;
        int numChoose;
        string pickedLetter;
        count = characterCount;
        while (count > 0)
        {
            int letterIndex = Random.Range(0, 4);
            if (letterIndex == 1)
            {
                letterChooseIndex = Random.Range(0, letters.Length);
                pickedLetter = letters[letterChooseIndex];
                count--;
                results.Add(pickedLetter);
            }
            if (letterIndex == 2)
            {
                letterChooseIndex = Random.Range(0, lettersCapital.Length);
                pickedLetter = lettersCapital[letterChooseIndex];
                count--;
                results.Add(pickedLetter);
            }
            if (letterIndex == 3 || letterIndex == 4)
            {
                letterChooseIndex = Random.Range(0, nums.Length);
                numChoose = nums[letterChooseIndex];
                count--;
                results.Add(numChoose.ToString());
            }
        }

    }

    public string GetRandomString()
    {
        GetRandomResult();
        string res = ConvertStringListToString(results);
        return res;
    }

    static string ConvertStringListToString(List<string> _list)
    {
        string result = string.Join("", _list);
        return result;
    }
}
