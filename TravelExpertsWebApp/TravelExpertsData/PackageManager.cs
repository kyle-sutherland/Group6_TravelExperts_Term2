namespace TravelExpertsData
{
    public static class PackageManager
    {
        public static List<Package> GetPackages(TravelExpertsContext db)
        {
            List<Package> packages = db.Packages.OrderBy(c => c.PackageId).ToList();
            return packages;
        }

        public static Package GetPackageById(TravelExpertsContext db, int packageId)
        {
            Package package = db.Packages.Find(packageId);
            return package;
        }


    }
}
