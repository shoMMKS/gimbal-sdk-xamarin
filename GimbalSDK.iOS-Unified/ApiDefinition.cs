﻿using System;
using CoreLocation;
using Foundation;
//using Gimbal;
using ObjCRuntime;
using UIKit;

namespace GimbalFramework
{
    // @interface GMBLApplicationStatus : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLApplicationStatus
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMBLApplicationStatusDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<GMBLApplicationStatusDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(GMBLLocationStatus)locationStatus;
        [Static]
        [Export("locationStatus")]
        //[Verify(MethodToProperty)]
        GMBLLocationStatus LocationStatus { get; }

        // +(GMBLBluetoothStatus)bluetoothStatus;
        [Static]
        [Export("bluetoothStatus")]
        //[Verify(MethodToProperty)]
        GMBLBluetoothStatus BluetoothStatus { get; }

        // +(NSString *)statusDescription;
        [Static]
        [Export("statusDescription")]
        //[Verify(MethodToProperty)]
        string StatusDescription { get; }
    }

    // @protocol GMBLApplicationStatusDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMBLApplicationStatusDelegate
    {
        // @optional -(void)applicationStatus:(GMBLApplicationStatus *)applicationStatus didChangeLocationStatus:(GMBLLocationStatus)locationStatus;
        [Export("applicationStatus:didChangeLocationStatus:")]
        void DidChangeLocationStatus(GMBLApplicationStatus applicationStatus, GMBLLocationStatus locationStatus);

        // @optional -(void)applicationStatus:(GMBLApplicationStatus *)applicationStatus didChangeBluetoothStatus:(GMBLBluetoothStatus)bluetoothStatus;
        [Export("applicationStatus:didChangeBluetoothStatus:")]
        void DidChangeBluetoothStatus(GMBLApplicationStatus applicationStatus, GMBLBluetoothStatus bluetoothStatus);
    }

    // @interface GMBLVisit : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLVisit : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) NSDate * arrivalDate;
        [Export("arrivalDate")]
        NSDate ArrivalDate { get; }

        // @property (readonly, nonatomic) NSTimeInterval dwellTime;
        [Export("dwellTime")]
        double DwellTime { get; }

        // @property (readonly, nonatomic) NSDate * departureDate;
        [Export("departureDate")]
        NSDate DepartureDate { get; }

        // @property (readonly, nonatomic) GMBLPlace * place;
        [Export("place")]
        GMBLPlace Place { get; }

        // @property (readonly, nonatomic) NSString * visitID;
        [Export("visitID")]
        string VisitID { get; }
    }

    // @interface GMBLPlaceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLPlaceManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMBLPlaceManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<GMBLPlaceManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(BOOL)isMonitoring;
        [Static]
        [Export("isMonitoring")]
        //Verify(MethodToProperty)]
        bool IsMonitoring { get; }

        // +(void)startMonitoring;
        [Static]
        [Export("startMonitoring")]
        void StartMonitoring();

        // +(void)stopMonitoring;
        [Static]
        [Export("stopMonitoring")]
        void StopMonitoring();

        // -(NSArray *)currentVisits;
        [Export("currentVisits")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] CurrentVisits { get; }
    }

    // @protocol GMBLPlaceManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMBLPlaceManagerDelegate
    {
        // @optional -(void)placeManager:(GMBLPlaceManager *)manager didBeginVisit:(GMBLVisit *)visit;
        [Export("placeManager:didBeginVisit:")]
        void DidBeginVisit(GMBLPlaceManager manager, GMBLVisit visit);

        // @optional -(void)placeManager:(GMBLPlaceManager *)manager didReceiveBeaconSighting:(GMBLBeaconSighting *)sighting forVisits:(NSArray *)visits;
        [Export("placeManager:didReceiveBeaconSighting:forVisits:")]
        //[Verify(StronglyTypedNSArray)]
        void DidReceiveBeaconSighting(GMBLPlaceManager manager, GMBLBeaconSighting sighting, NSObject[] visits);

        // @optional -(void)placeManager:(GMBLPlaceManager *)manager didEndVisit:(GMBLVisit *)visit;
        [Export("placeManager:didEndVisit:")]
        void DidEndVisit(GMBLPlaceManager manager, GMBLVisit visit);

        // @optional -(void)placeManager:(GMBLPlaceManager *)manager didDetectLocation:(CLLocation *)location;
        [Export("placeManager:didDetectLocation:")]
        void DidDetectLocation(GMBLPlaceManager manager, CLLocation location);
    }

    // @interface GMBLPlace : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLPlace : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) NSString * identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic) NSString * name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) GMBLAttributes * attributes;
        [Export("attributes")]
        GMBLAttributes Attributes { get; }
    }

    // @interface GMBLAttributes : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLAttributes : INSCopying, INSSecureCoding
    {
        // -(NSArray *)allKeys;
        [Export("allKeys")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] AllKeys { get; }

        // -(NSString *)stringForKey:(NSString *)key;
        [Export("stringForKey:")]
        string StringForKey(string key);
    }

    // @interface GMBLCommunicationManager : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLCommunicationManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMBLCommunicationManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<GMBLCommunicationManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(void)startReceivingCommunications;
        [Static]
        [Export("startReceivingCommunications")]
        void StartReceivingCommunications();

        // +(void)stopReceivingCommunications;
        [Static]
        [Export("stopReceivingCommunications")]
        void StopReceivingCommunications();

        // +(BOOL)isReceivingCommunications;
        [Static]
        [Export("isReceivingCommunications")]
        //[Verify(MethodToProperty)]
        bool IsReceivingCommunications { get; }

        // +(GMBLCommunication *)communicationForRemoteNotification:(NSDictionary *)userInfo;
        [Static]
        [Export("communicationForRemoteNotification:")]
        GMBLCommunication CommunicationForRemoteNotification(NSDictionary userInfo);

        // +(GMBLCommunication *)communicationForLocalNotification:(UILocalNotification *)notification;
        [Static]
        [Export("communicationForLocalNotification:")]
        GMBLCommunication CommunicationForLocalNotification(UILocalNotification notification);
    }

    // @protocol GMBLCommunicationManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMBLCommunicationManagerDelegate
    {
        // @optional -(NSArray *)communicationManager:(GMBLCommunicationManager *)manager presentLocalNotificationsForCommunications:(NSArray *)communications forVisit:(GMBLVisit *)visit;
        [Export("communicationManager:presentLocalNotificationsForCommunications:forVisit:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        NSObject[] CommunicationManager(GMBLCommunicationManager manager, NSObject[] communications, GMBLVisit visit);

        // @optional -(UILocalNotification *)communicationManager:(GMBLCommunicationManager *)manager prepareNotificationForDisplay:(UILocalNotification *)notification forCommunication:(GMBLCommunication *)communication;
        [Export("communicationManager:prepareNotificationForDisplay:forCommunication:")]
        UILocalNotification CommunicationManager(GMBLCommunicationManager manager, UILocalNotification notification, GMBLCommunication communication);
    }

    // @interface GMBLCommunication : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLCommunication : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) NSString * identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic) NSString * title;
        [Export("title")]
        string Title { get; }

        // @property (readonly, nonatomic) NSString * descriptionText;
        [Export("descriptionText")]
        string DescriptionText { get; }

        // @property (readonly, nonatomic) NSString * URL;
        [Export("URL")]
        string URL { get; }

        // @property (readonly, nonatomic) NSDate * deliveryDate;
        [Export("deliveryDate")]
        NSDate DeliveryDate { get; }

        // @property (readonly, nonatomic) NSDate * expiryDate;
        [Export("expiryDate")]
        NSDate ExpiryDate { get; }

        // @property (readonly, nonatomic) GMBLAttributes * attributes;
        [Export("attributes")]
        GMBLAttributes Attributes { get; }
    }

    // @interface GMBLBeaconManager : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLBeaconManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMBLBeaconManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<GMBLBeaconManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)startListening;
        [Export("startListening")]
        void StartListening();

        // -(void)stopListening;
        [Export("stopListening")]
        void StopListening();
    }

    // @protocol GMBLBeaconManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMBLBeaconManagerDelegate
    {
        // @required -(void)beaconManager:(GMBLBeaconManager *)manager didReceiveBeaconSighting:(GMBLBeaconSighting *)sighting;
        [Abstract]
        [Export("beaconManager:didReceiveBeaconSighting:")]
        void DidReceiveBeaconSighting(GMBLBeaconManager manager, GMBLBeaconSighting sighting);
    }

    // @interface GMBLBeaconSighting : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLBeaconSighting : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) NSInteger RSSI;
        [Export("RSSI")]
        nint RSSI { get; }

        // @property (readonly, nonatomic) NSDate * date;
        [Export("date")]
        NSDate Date { get; }

        // @property (readonly, nonatomic) GMBLBeacon * beacon;
        [Export("beacon")]
        GMBLBeacon Beacon { get; }
    }

    // @interface GMBLBeacon : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLBeacon : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) NSString * identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic) NSString * uuid;
        [Export("uuid")]
        string Uuid { get; }

        // @property (readonly, nonatomic) NSString * name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * iconURL;
        [Export("iconURL")]
        string IconURL { get; }

        // @property (readonly, nonatomic) GMBLBatteryLevel batteryLevel;
        [Export("batteryLevel")]
        GMBLBatteryLevel BatteryLevel { get; }

        // @property (readonly, nonatomic) NSInteger temperature;
        [Export("temperature")]
        nint Temperature { get; }
    }

    // @interface GMBLDebugger : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLDebugger
    {
        // +(void)enableBeaconSightingsLogging;
        [Static]
        [Export("enableBeaconSightingsLogging")]
        void EnableBeaconSightingsLogging();

        // +(void)disableBeaconSightingsLogging;
        [Static]
        [Export("disableBeaconSightingsLogging")]
        void DisableBeaconSightingsLogging();

        // +(BOOL)isBeaconSightingsEnabled;
        [Static]
        [Export("isBeaconSightingsEnabled")]
        //[Verify(MethodToProperty)]
        bool IsBeaconSightingsEnabled { get; }
    }

    // @interface GMBLEstablishedLocationManager : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLEstablishedLocationManager
    {
        // +(void)startMonitoring;
        [Static]
        [Export("startMonitoring")]
        void StartMonitoring();

        // +(void)stopMonitoring;
        [Static]
        [Export("stopMonitoring")]
        void StopMonitoring();

        // +(BOOL)isMonitoring;
        [Static]
        [Export("isMonitoring")]
        //[Verify(MethodToProperty)]
        bool IsMonitoring { get; }

        // +(NSArray *)establishedLocations;
        [Static]
        [Export("establishedLocations")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] EstablishedLocations { get; }
    }

    // @interface GMBLEstablishedLocation : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLEstablishedLocation : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) double score;
        [Export("score")]
        double Score { get; }

        // @property (readonly, nonatomic) GMBLCircle * boundary;
        [Export("boundary")]
        GMBLCircle Boundary { get; }
    }

    // @interface GMBLCircle : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    interface GMBLCircle : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationCoordinate2D center;
        [Export("center")]
        CLLocationCoordinate2D Center { get; }

        // @property (readonly, nonatomic) CLLocationDistance radius;
        [Export("radius")]
        double Radius { get; }
    }

    // @interface Gimbal : NSObject
    [BaseType(typeof(NSObject))]
    interface Gimbal
    {
        // +(void)setAPIKey:(NSString *)APIKey options:(NSDictionary *)options;
        [Static]
        [Export("setAPIKey:options:")]
        void SetAPIKey(string APIKey, NSDictionary options);

        // +(NSString *)applicationInstanceIdentifier;
        [Static]
        [Export("applicationInstanceIdentifier")]
        //[Verify(MethodToProperty)]
        string ApplicationInstanceIdentifier { get; }

        // +(void)resetApplicationInstanceIdentifier;
        [Static]
        [Export("resetApplicationInstanceIdentifier")]
        void ResetApplicationInstanceIdentifier();

        // +(void)setPushDeviceToken:(NSData *)deviceToken;
        [Static]
        [Export("setPushDeviceToken:")]
        void SetPushDeviceToken(NSData deviceToken);
    }

}


namespace GimbalExperienceFramework
{
    // @interface GMBLAction : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLAction
    {
        // @property (readonly, nonatomic) GMBLActionType actionType;
        [Export("actionType")]
        GMBLActionType ActionType { get; }

        // @property (readonly, nonatomic) GMBLForegroundBehavior behavior;
        [Export("behavior")]
        GMBLForegroundBehavior Behavior { get; }

        // @property (readonly, nonatomic) NSArray * tags;
        [Export("tags")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Tags { get; }

        // @property (readonly, nonatomic) GMBLVisit * visit;
        [Export("visit")]
        GimbalFramework.GMBLVisit Visit { get; }

        // @property (readonly, nonatomic) NSString * notificationTitle;
        [Export("notificationTitle")]
        string NotificationTitle { get; }

        // @property (readonly, nonatomic) NSString * notificationMessage;
        [Export("notificationMessage")]
        string NotificationMessage { get; }
    }

    // @protocol GMBLExperienceManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMBLExperienceManagerDelegate
    {
        // @optional -(NSArray *)experienceManager:(GMBLExperienceManager *)experienceManager filterActions:(NSArray *)receivedActions;
        [Export("experienceManager:filterActions:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        NSObject[] ExperienceManager(GMBLExperienceManager experienceManager, NSObject[] receivedActions);

        // @optional -(void)experienceManager:(GMBLExperienceManager *)experienceManager presentViewController:(UIViewController *)actionViewController forAction:(GMBLAction *)action;
        [Export("experienceManager:presentViewController:forAction:")]
        void ExperienceManager(GMBLExperienceManager experienceManager, UIViewController actionViewController, GMBLAction action);

        // @optional -(UILocalNotification *)experienceManager:(GMBLExperienceManager *)manager prepareNotificationForDisplay:(UILocalNotification *)notification forAction:(GMBLAction *)action;
        [Export("experienceManager:prepareNotificationForDisplay:forAction:")]
        UILocalNotification ExperienceManager(GMBLExperienceManager manager, UILocalNotification notification, GMBLAction action);
    }

    // @interface GMBLExperienceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface GMBLExperienceManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMBLExperienceManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<GMBLExperienceManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(BOOL)isMonitoring;
        [Static]
        [Export("isMonitoring")]
        //[Verify(MethodToProperty)]
        bool IsMonitoring { get; }

        // +(void)startExperiences;
        [Static]
        [Export("startExperiences")]
        void StartExperiences();

        // +(void)stopExperiences;
        [Static]
        [Export("stopExperiences")]
        void StopExperiences();

        // +(GMBLAction *)actionForLocalNotification:(UILocalNotification *)notification;
        [Static]
        [Export("actionForLocalNotification:")]
        GMBLAction ActionForLocalNotification(UILocalNotification notification);

        // +(void)didReceiveExperienceAction:(GMBLAction *)action;
        [Static]
        [Export("didReceiveExperienceAction:")]
        void DidReceiveExperienceAction(GMBLAction action);
    }
}


