using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LinkGoogleSheet
{
    // ���� ���������Ʈ ��ũ
    private string URL = "";

    public LinkGoogleSheet(string url)
    {
        URL = url;
    }

    // ��ȭ ����
    private string[][] _text;
    public string[][] Text => _text;

    /// <summary>
    /// ���� ���������Ʈ ���� �ҷ�����
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
    /// ��� ��������
    /// </summary>
    /// <param name="height"></param>
    /// <param name="weight"></param>
    /// <returns></returns>
    public string GetText(int height, int weight)
    {
        return Text[height][weight];
    }
}
