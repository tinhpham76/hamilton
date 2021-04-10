namespace Core.Libs.Integration.GoogleMap.Models.Enum.Routes.DistanceMatrix
{
    public enum TravelMode
    {
        Driving, // (default) indicates standard driving directions using the road network.
        Walking, // requests walking directions via pedestrian paths & sidewalks (where available).
        Bicycling, // requests bicycling directions via bicycle paths & preferred streets (where available).
        Transit, // requests directions via public transit routes (where available). 
    }
}