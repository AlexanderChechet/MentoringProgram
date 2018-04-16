using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3SLinqProvider.E3SClient.Entities
{
    public class Education
    {
        public string institution { get; set; }
        public string degree { get; set; }
        public string department { get; set; }
        public string faculty { get; set; }
        public string graduationYear { get; set; }
    }

    public class Cert
    {
        public string name { get; set; }
        public string year { get; set; }
    }

    public class Staff
    {
        public string origin { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class Hero
    {
        public string origin { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class UPSA
    {
        public string origin { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class Yammer
    {
        public string origin { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class Profile
    {
        public List<Staff> Staff { get; set; }
        public List<Hero> Hero { get; set; }
        public List<UPSA> UPSA { get; set; }
        public List<Yammer> Yammer { get; set; }
    }

    public class Badge
    {
        public string id { get; set; }
        public string image { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public bool e3sImageExists { get; set; }
    }

    public class Vacation
    {
        public object startDate { get; set; }
        public object endDate { get; set; }
        public string label { get; set; }
    }

    public class Coordinates
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class ProjectWorkload
    {
        public string projectId { get; set; }
        public string project { get; set; }
        public bool isBillable { get; set; }
        public string workload { get; set; }
        public string wWeighted { get; set; }
        public string position { get; set; }
        public List<string> skills { get; set; }
        public string positionType { get; set; }
        public string positionId { get; set; }
        public string positionState { get; set; }
    }

    public class Workload
    {
        public string startDate { get; set; }
        public List<ProjectWorkload> projectWorkload { get; set; }
    }

    public class ActualProject
    {
        public string projectId { get; set; }
        public string project { get; set; }
    }

    public class E3sExtensions
    {
    }

    public class Key
    {
        public string id { get; set; }
        public string type { get; set; }
        public string fullKey { get; set; }
    }

    public class Skill
    {
        public string advanced { get; set; }
        public string intermediate { get; set; }
        public string novice { get; set; }
        public string position { get; set; }
        public string primary { get; set; }
    }

    public class E3sAttributes
    {
        public string _e3sNode { get; set; }
    }

    public class Yammer2
    {
        public string origin { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class Social
    {
        public List<Yammer2> Yammer { get; set; }
    }

    [E3SMetaType("meta:people-suite:people-api:com.epam.e3s.app.people.api.data.pluggable.EmployeeEntity")]
    public class EmployeeEntity : E3SEntity
    {
        public string workStation { get; set; }
        public List<Education> education { get; set; }
        public string _e3sId { get; set; }
        public List<Cert> cert { get; set; }
        public string employmentStatus { get; set; }
        public string unitHead { get; set; }
        public string id { get; set; }
        public string upsaId { get; set; }
        public Profile profile { get; set; }
        public double ipDedicated { get; set; }
        public long _e3sCreated { get; set; }
        public string citySum { get; set; }
        public List<Badge> badge { get; set; }
        public bool isRm { get; set; }
        public long _e3sUpdated { get; set; }
        public List<string> phone { get; set; }
        public int _e3sVersion { get; set; }
        public string lastName { get; set; }
        public string nativeName { get; set; }
        public string orgCategory { get; set; }
        public List<string> city { get; set; }
        public string unitPath { get; set; }
        public string displayName { get; set; }
        public string availability { get; set; }
        public List<string> skype { get; set; }
        public List<Vacation> vacation { get; set; }
        public string projectAll { get; set; }
        public List<string> sourceIds { get; set; }
        public List<string> email { get; set; }
        public string workPlace { get; set; }
        public string softwarePackage { get; set; }
        public string manager { get; set; }
        public Coordinates coordinates { get; set; }
        public List<Workload> workload { get; set; }
        public List<string> photo { get; set; }
        public string reporter { get; set; }
        public List<string> url { get; set; }
        public List<string> socialNetwork { get; set; }
        public string primaryTitle { get; set; }
        public string cefr { get; set; }
        public List<string> country { get; set; }
        public string recognitionScore { get; set; }
        public string primarySkill { get; set; }
        public List<string> dl { get; set; }
        public string project { get; set; }
        public string office { get; set; }
        public string countrySum { get; set; }
        public List<ActualProject> actualProjects { get; set; }
        public double nonBillable { get; set; }
        public E3sExtensions _e3sExtensions { get; set; }
        public double documentBoost { get; set; }
        public string firstName { get; set; }
        public List<string> hrContact { get; set; }
        public string region { get; set; }
        public List<string> deliveryManager { get; set; }
        public List<Key> keys { get; set; }
        public List<string> phones { get; set; }
        public List<string> hero { get; set; }
        public List<string> title { get; set; }
        public double nonBillableA { get; set; }
        public List<string> superiors { get; set; }
        public string principal { get; set; }
        public Skill skill { get; set; }
        public string englishAssessmentState { get; set; }
        public List<string> phoneticFullName { get; set; }
        public double npa { get; set; }
        public string unitHeads { get; set; }
        public List<string> unitContact { get; set; }
        public E3sAttributes _e3sAttributes { get; set; }
        public Social social { get; set; }
        public List<string> fullName { get; set; }
        public double billable { get; set; }
        public string room { get; set; }
        public List<string> heroProgram { get; set; }
        public string superior { get; set; }
        public string shortStartWorkDate { get; set; }
        public bool timeJournal { get; set; }
    }
}
