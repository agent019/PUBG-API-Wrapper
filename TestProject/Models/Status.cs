using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Status
    {
        public string Id { get; set; }
        public DateTime Released { get; set; }
        public string Version { get; set; }

        public override string ToString()
        {
            return "Version: " + Version + "\nDate Released: " + Released;
        }
    }

    #region DTO

    public class StatusDTO
    {
        public StatusData Data { get; set; }
    }

    public class StatusData
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public StatusAttributes Attributes { get; set; }
    }

    public class StatusAttributes
    {
        public string ReleasedAt { get; set; }
        public string Version { get; set; }
    }

    #endregion
}
