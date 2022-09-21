using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LinkGoogleSheet
{
    // 구글 스프레드시트 링크
    private string URL = "";

    public LinkGoogleSheet(string url)
    {
        URL = url;
    }

    // 대화 저장
    private string[][] _text;
    public string[][] Text => _text;

    /// <summary>
    /// 구글 스프레드시트 내용 불러오기
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadGoogleSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        string[] line = data.Split('\n');
        
        for(int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            for(int j = 0; j < row.Length; j++)
            {
                Text[i][j] = row[j].Trim();
            }
        }
    }

    /// <summary>
    /// 대사 가져오기
    /// </summary>
    /// <param name="height"></param>
    /// <param name="weight"></param>
    /// <returns></returns>
    public string GetText(int height, int weight)
    {
        return Text[height][weight];
    }
}
