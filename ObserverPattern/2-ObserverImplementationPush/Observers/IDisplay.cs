﻿namespace ObserverPattern._2_ObserverImplementationPush.Observers;

/*
 * We separate out the IDisplay interface and the IObserver interface to componentize 
 * our application. This allows us flexibility in our design, e.g. we can create an
 * observer that has no display, perhaps it calls an API on update etc.
 */
public interface IDisplay
{
    public string Display();
}