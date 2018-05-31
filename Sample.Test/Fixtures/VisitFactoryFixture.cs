using System;
using MainProject.Factories;
using Moq;

namespace Sample.Test.Fixtures
{
    public class VisitFactoryFixture
    {
        public IDoctorService doctorService;
        public VisitFactory CreateSut()
        {
            doctorService = new Mock<IDoctorService>().Object;
            return new VisitFactory(doctorService);
        }
    }
}