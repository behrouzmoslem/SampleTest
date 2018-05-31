using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Factories;
using Sample.Test.Fixtures;

namespace Sample.Test.VisitFactoryTest
{
    public class Given_VisitFactory:AAA
    {
        protected VisitFactory Sut;
        protected VisitFactoryFixture visitFactoryFixture;
        public override void Arrage()
        {
            base.Arrage();
            visitFactoryFixture = new VisitFactoryFixture();
            Sut = visitFactoryFixture.CreateSut();
        }
    }
}
