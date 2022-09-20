using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LinkGoogleSheet
{
    // 구글 스프레드시트 링크
    private const string URL = "https://docs.google.com/spreadsheets/d/18d1eO7_f3gewvcBi5MIe0sqh50lp1PF-kkQg2nm03wg/export?format=tsv";

    // 대화 저장
    private string _text;
    public string Text => _text;

    /// <summary>
    /// 구글 스프레드시트 내용 불러오기
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadGoogleSheet(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
    }

    /// <summary>
    /// 대사 가져오기
    /// </summary>
    /// <param name="height"></param>
    /// <param name="weight"></param>
    /// <returns></returns>
    public string GetText(int height, int weight)
    {
        return _text;
    }
}
