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
        private IDoctorService doctorService;

        public VisitFactory(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public TaminPrescriptionDto Create(ReceptionDs receptionDs)
        {
            var result=new TaminPrescriptionDto();
            result.HeadPrescriptionDto = new TaminHeadPrescriptionDto();
            result.DetailEpresclist = new List<TaminDetailPrescriptionDto>();
            result.HeadPrescriptionDto.PrescType = 3;
            result.HeadPrescriptionDto.DocId = int.Parse(receptionDs.Doctor.MedicalNo).ToString();
            result.HeadPrescriptionDto.PrescDate = "13"+receptionDs.ReceptionDate.Replace("/", "");
            result.HeadPrescriptionDto.SrvType = null;
            try
            {
               result.HeadPrescriptionDto.DocSpec =
                doctorService.GetTaminSpeciality(Convert.ToInt32(receptionDs.Doctor.MajorExpert.Id)).ToString();
            }
            catch (Exception e)
            {
              throw new Exception();
            }
            
            return result;
        }
    }
}
