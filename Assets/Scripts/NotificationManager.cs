using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
    using Unity.Notifications.Android;
#elif UNITY_IOS
    using Unity.Notifications.iOS;
#endif

public class NotificationManager : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Ready ?";
        notification.Text = "The roofs are waiting for you !";
        notification.FireTime = System.DateTime.Now.AddHours(12);
        notification.RepeatInterval = new System.TimeSpan(12,0,0);

        var id = AndroidNotificationCenter.SendNotification(notification, "default_channel");

        var notificationStatus = AndroidNotificationCenter.CheckScheduledNotificationStatus(id);

        if (notificationStatus == NotificationStatus.Delivered)
        {
            // Remove the previously shown notification from the status bar.
            AndroidNotificationCenter.CancelNotification(id);
        }

        AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler =
    delegate (AndroidNotificationIntentData data)
    {
        var msg = "Notification received : " + data.Id + "\n";
        msg += "\n Notification received: ";
        msg += "\n .Title: " + data.Notification.Title;
        msg += "\n .Body: " + data.Notification.Text;
        msg += "\n .Channel: " + data.Channel;
        Debug.Log(msg);
    };

        AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;
#elif UNITY_IOS

        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(12, 0, 0),
            Repeats = true
        };

        var notification = new iOSNotification()
        {
            // You can specify a custom identifier which can be used to manage the notification later.
            // If you don't provide one, a unique string will be generated automatically.
            Identifier = "_notification_01",
            Title = "Ready ?",
            Body = "The roofs are waiting for you !",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notification);

        iOSNotificationCenter.RemoveDeliveredNotification(notification.Identifier);

#endif
    }
}
