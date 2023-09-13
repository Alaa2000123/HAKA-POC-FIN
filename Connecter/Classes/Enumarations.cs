namespace Classes
{
    public enum Service : int
    {

        Insurance = 1,
        FleetManagement = 2,
        /*MOIProjectRequest = 33 */ //add new service
    }
    public enum ServiceTypes : int
    {
        Insurance = 1,
        FleetManagement = 2,
        /*MOIProject = 86 *///add new
    }

    public enum LookupGroups : int
    {
        Branch = 1,
        Department = 2,
        Export_office = 3,
        Complaining_parties = 4,
        Complaint_Method = 5,
        Audit_Status = 6,
        AreaID = 7 // add new
    }

    public enum Steps : int
    {
        Requester = 1,
        LineManager = 2,
        HR = 3,
        Administration = 4,
     
    }

    public enum Actions : int
    {
        Approved = 1,
        Rejected = 2,
        Completed = 3,
        CompletedandintegrationforInsurancecompany = 4,
    }

    public class Constants
    {
        public const int EmployeeId = 1;
        public const string UserGroup = "user";
        public const string FleetManagementWF = "WorkFlow\\Fleet Management";
        public const string InsuranceWF = "WorkFlow\\Insurance";
    }
}

