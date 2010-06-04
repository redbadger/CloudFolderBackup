namespace RedBadger.CloudFolderBackup.Extensions
{
    using System.Collections.Generic;

    public static class ICollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}