namespace OrdinaMTech.Cv.WebApi.Services
{
    public static class AuditLog
    {
        private static string _LaatstGeraadpleegdDoor;

        public static string LaatstGeraadpleegdDoor
        {
            get
            {
                return _LaatstGeraadpleegdDoor;
            }
            set
            {
                if (_LaatstGeraadpleegdDoor == null)
                {
                    _LaatstGeraadpleegdDoor = value;
                }
            }
        }
    }
}
