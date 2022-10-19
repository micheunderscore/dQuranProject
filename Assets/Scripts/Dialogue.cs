using System;
using System.Reflection;

[Serializable]
public class Dialogues {
    public Dialogue[] dialogues;
}

[Serializable]
public class Dialogue {
    public string title;
    public Language languages;
}

[Serializable]
public class Language {
    public Dialog[] my;
    public Dialog[] en;
}

[Serializable]
public class Dialog {
    public string name;
    public string sentence;
}
