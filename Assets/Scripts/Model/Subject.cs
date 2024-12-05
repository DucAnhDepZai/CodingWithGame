
using System.Collections.Generic;

public class Subject 
{
    public int id { get; set; }
    public string scene { get; set; }
    public bool done { get; set; }
    public List<string> chat { get; set; }
    public Subject() { }
    public Subject(int id, string scene,bool done, List<string> chat)
    {
        this.id = id;
        this.scene = scene;
        this.done = done;
        this.chat = chat;
    }

}
