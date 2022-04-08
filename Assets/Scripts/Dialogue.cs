using System;
using System.Reflection;

[Serializable]
public class Dialogue {
    public Language conversation;
}

[Serializable]
public class Language {
    public Convo[] my;
    public Convo[] en;
}

[Serializable]
public class Convo {
    public string name;
    public string sentence;
}
