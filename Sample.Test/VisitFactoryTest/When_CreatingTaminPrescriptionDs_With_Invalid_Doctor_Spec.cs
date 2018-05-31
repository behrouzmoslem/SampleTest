using System;
using DataStructure;
using Moq;
using Sample.Test.Builders;
using Xunit;

namespace Sample.Test.VisitFactoryTest
{
    public class When_CreatingTaminPrescriptionDs_With_Invalid_Doctor_Spec : Given_VisitFactory
    {
        private ReceptionDs receptionDs;
        private TaminPrescriptionDto result;
        private Exception exception;
        public override void Arrage()
        {
            base.Arrage();
            receptionDs = new ReceptionBuilder();
            visitFactoryFixture.doctorService.AsMock()
                .Setup(a => a.GetTaminSpeciality(It.IsAny<int?>()))
                .Throws<Exception>();
        }

        public override void Act()
        {
            base.Act();
            try
            {
                result = Sut.Create(receptionDs);
            }
            catch (Exception e)
            {
                exception = e;
            }
           
        }

        [Fact]
        public void Then_Tamin_Visit_Invalid_Doctor_Spect_MustBe_Exception()
        {
            Assert.IsType<Exception>(exception);
        }
    }
}