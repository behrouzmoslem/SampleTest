using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using Moq;
using Sample.Test.Builders;
using Xunit;

namespace Sample.Test.VisitFactoryTest
{
    public class When_CreatingTaminPrescriptionDs:Given_VisitFactory
    {
        private ReceptionDs receptionDs;
        private TaminPrescriptionDto result;
        public override void Arrage()
        {
            base.Arrage();
            receptionDs=new ReceptionBuilder();
            visitFactoryFixture.doctorService.AsMock()
                .Setup(a => a.GetTaminSpeciality(It.IsAny<int?>()))
                .Returns(1);
        }

        public override void Act()
        {
            base.Act();
            result = Sut.Create(receptionDs);
        }

        [Fact]
        public void Then_Tamin_Visit_Prescription_Type_Is_Same_Three()
        {
            Assert.Equal(result.HeadPrescriptionDto.PrescType,3);
        }

        [Fact]
        public void Then_Tamin_Visit_Detail_Prescription_MustBe_Count_Is_Zero()
        {
            Assert.Equal(0, result.DetailEpresclist.Count());
        }

        [Fact]
        public void Then_Tamin_Visit_Date_Prescription_Should_Not_Has_Slash()
        {
            Assert.Equal(result.HeadPrescriptionDto.PrescDate,"13"+receptionDs.ReceptionDate.Replace("/",""));
        }

        [Fact]
        public void Then_Tamin_Visit_Date_MustBe_Eight_Characters()
        {
            Assert.Equal(8,result.HeadPrescriptionDto.PrescDate.Length);
        }
        [Fact]
        public void Then_DocId_Is_Same_As_Doctors_Medical_No_Without_Zeros()
        {
            var expected = receptionDs.Doctor.MedicalNo.Replace("0", "");
            Assert.Equal(expected, result.HeadPrescriptionDto.DocId);
        }

        [Fact]
        public void Then_Tamin_Visit_Service_Type_Is_Null()
        {
            Assert.Equal(null,result.HeadPrescriptionDto.SrvType);
        }

        [Fact]
        public void Then_Tamin_Visit_DoctorSpect_Is_Exist()
        {
            var expect = visitFactoryFixture.doctorService.GetTaminSpeciality(1);
            Assert.Equal(expect.ToString(),result.HeadPrescriptionDto.DocSpec);
        }
    }
}
