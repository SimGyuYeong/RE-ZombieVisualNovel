using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LinkGoogleSheet
{
    // ���� ���������Ʈ ��ũ
    private const string URL = "https://docs.google.com/spreadsheets/d/18d1eO7_f3gewvcBi5MIe0sqh50lp1PF-kkQg2nm03wg/export?format=tsv";

    // ��ȭ ����
    private string _text;
    public string Text => _text;

    /// <summary>
    /// ���� ���������Ʈ ���� �ҷ�����
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadGoogleSheet(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
    }

    /// <summary>
    /// ��� ��������
    /// </summary>
    /// <param name="height"></param>
    /// <param name="weight"></param>
    /// <returns></returns>
    public string GetText(int height, int weight)
    {
        return _text;
    }
}
