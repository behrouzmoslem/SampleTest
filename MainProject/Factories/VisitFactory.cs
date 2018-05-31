using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using MainProject.Entities.Source;

namespace MainProject.Factories
{
    public class VisitFactory
    {
        public TaminPrescriptionDto Create(ReceptionDs receptionDs)
        {
            var result=new TaminPrescriptionDto();
            result.HeadPrescriptionDto = new TaminHeadPrescriptionDto();
            result.DetailEpresclist = new List<TaminDetailPrescriptionDto>();
            result.HeadPrescriptionDto.PrescType = 3;
            result.HeadPrescriptionDto.DocId = int.Parse(receptionDs.Doctor.MedicalNo).ToString();
            result.HeadPrescriptionDto.PrescDate = "13"+receptionDs.ReceptionDate.Replace("/", "");
            return result;
        }
    }
}
