using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Factories;

namespace Sample.Test.VisitFactoryTest
{
    public class Given_VisitFactory:AAA
    {
        protected VisitFactory Sut;
        public override void Arrage()
        {
            base.Arrage();
            Sut=new VisitFactory();
        }
    }
}
