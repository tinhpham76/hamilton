namespace Core.Libs.Integration.GoogleMap.Models.Enum.Routes.DistanceMatrix
{
    public enum Avoid
    {
        Tolls, //  indicates that the calculated route should avoid toll roads/bridges.
        Highways, // indicates that the calculated route should avoid highways.
        Ferries, // indicates that the calculated route should avoid ferries.
        Indoor, // indicates that the calculated route should avoid indoor steps for walking and transit directions.
    }
}