//Created by: Kyle and Tim
namespace TravelExpertsData
{
    public static class PackageManager
    {
        /// <summary>
        /// returns the packages ordered by package Id
        /// </summary>
        /// <param name="db">context</param>
        /// <returns></returns>
        public static List<Package> GetPackages(TravelExpertsContext db)
        {
            List<Package> packages = db.Packages.OrderBy(c => c.PackageId).ToList();
            return packages;
        }

        /// <summary>
        /// returns a specific package by its Id 
        /// </summary>
        /// <param name="db">context</param>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public static Package GetPackageById(TravelExpertsContext db, int packageId)
        {
            Package package = db.Packages.Find(packageId);
            return package;
        }
    }
}
