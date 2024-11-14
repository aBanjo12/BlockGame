using System.Collections.Generic;

namespace BlockGame.Event;

public static class EventHandler
{
    public static List<Event> Events = new();

    public static void Update()
    {
        foreach (var e in Events)
        {
            e.Execute();
        }
    }
}