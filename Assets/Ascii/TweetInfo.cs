using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TweetInfo", menuName = "Ascii/TweetInfo", order = 1)]
public class TweetInfo : ScriptableObject
{
    [SerializeField, Header("UnityRoomのゲームID")]
    private string gameId;
    public string GameId => gameId;
    [SerializeField, Header("ツイート内容")]
    private string tweetContent;
    public string TweetContent => tweetContent;
    [SerializeField, Header("ハッシュタグ")]
    private string hashTag;
    public string HashTag => hashTag;
}
