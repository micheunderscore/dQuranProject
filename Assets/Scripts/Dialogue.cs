using System;
using UnityEngine;

[Serializable]
public class Dialogue {
    public Convo[] conversation;
}

[Serializable]
public class Convo {
    public string name;
    public string sentence;
}
