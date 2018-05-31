using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities.Source
{
    public class TaminHeader
    {

        public string TAREF_CODE { get; set; }

        public string Tracking_Code { get; set; }

        public string CUST_NO { get; set; }

        public string CUST_TYPE { get; set; }

        public string DB_LINKS_ID { get; set; }
        public string PatientID { get; set; }

        public string DOCID { get; set; }
        public string DocTypeID { get; set; }

        public string DOC_SPEC { get; set; }

        public string PrescDate { get; set; }

        public string COMMENTS { get; set; }

        public string PatientMobile { get; set; }

        public string Patient_FName { get; set; }

        public string Patient_LName { get; set; }

        public int PrescType { get; set; }

        public string SRV_Type { get; set; }

        public string PAR_GRP_CODE { get; set; }

    }
}
